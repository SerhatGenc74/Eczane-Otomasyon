using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EczaneOtomasyon.Infrastructure.Repositories
{
    public class SatislarRepository : RepositoryBase<Satislar>, ISatislarRepository
    {
        public bool CompleteSale(Satislar satis, List<SatisDetay> detaylar, out string errorMessage)
        {
            errorMessage = null;
            if (satis == null)
            {
                errorMessage = "Satis bilgisi eksik.";
                return false;
            }

            if (detaylar == null || detaylar.Count == 0)
            {
                errorMessage = "Satis kalemi yok.";
                return false;
            }

            using (SqlConnection conn = Connection.GetConnection())
            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    // Insert Satislar and get inserted id
                    const string insertSatisSql =
                        "INSERT INTO Satislar (FaturaNo, Tarih, SatisTuru, ReceteID, ToplamTutar, IndirimTutari, OdemeYontemi, KullaniciID) " +
                        "VALUES (@FaturaNo, @Tarih, @SatisTuru, @ReceteID, @ToplamTutar, @IndirimTutari, @OdemeYontemi, @KullaniciID); " +
                        "SELECT CAST(SCOPE_IDENTITY() as int);";

                    using (SqlCommand cmd = new SqlCommand(insertSatisSql, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@FaturaNo", (object)satis.FaturaNo ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Tarih", satis.Tarih);
                        cmd.Parameters.AddWithValue("@SatisTuru", (object)satis.SatisTuru ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ReceteID", (object)satis.ReceteID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ToplamTutar", satis.ToplamTutar);
                        cmd.Parameters.AddWithValue("@IndirimTutari", satis.IndirimTutari);
                        cmd.Parameters.AddWithValue("@OdemeYontemi", (object)satis.OdemeYontemi ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@KullaniciID", (object)satis.KullaniciID ?? DBNull.Value);

                        satis.SatisID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    foreach (SatisDetay det in detaylar)
                    {
                        if (!det.IlacID.HasValue)
                        {
                            throw new Exception("Ilac bilgisi eksik.");
                        }

                        int currentStock;
                        const string selectStockSql =
                            "SELECT StokAdedi FROM Ilaclar WITH (UPDLOCK, ROWLOCK) WHERE IlacID = @IlacID";
                        using (SqlCommand cmd = new SqlCommand(selectStockSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@IlacID", det.IlacID.Value);
                            object res = cmd.ExecuteScalar();
                            if (res == null || res == DBNull.Value)
                            {
                                throw new Exception("Ilac bulunamadi: " + det.IlacID.Value);
                            }
                            currentStock = Convert.ToInt32(res);
                        }

                        if (currentStock < det.Adet)
                        {
                            tran.Rollback();
                            errorMessage = "Ilac (ID=" + det.IlacID.Value + ") icin yeterli stok yok. Mevcut: " + currentStock + ", talep: " + det.Adet;
                            return false;
                        }

                        const string insertDetSql =
                            "INSERT INTO SatisDetay (SatisID, IlacID, Adet, SatisBirimFiyati, AraToplam) " +
                            "VALUES (@SatisID, @IlacID, @Adet, @SatisBirimFiyati, @AraToplam);";
                        using (SqlCommand cmd = new SqlCommand(insertDetSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@SatisID", satis.SatisID);
                            cmd.Parameters.AddWithValue("@IlacID", det.IlacID.Value);
                            cmd.Parameters.AddWithValue("@Adet", det.Adet);
                            cmd.Parameters.AddWithValue("@SatisBirimFiyati", det.SatisBirimFiyati);
                            cmd.Parameters.AddWithValue("@AraToplam", det.AraToplam);
                            cmd.ExecuteNonQuery();
                        }

                        const string updateStockSql =
                            "UPDATE Ilaclar SET StokAdedi = StokAdedi - @Adet WHERE IlacID = @IlacID";
                        using (SqlCommand cmd = new SqlCommand(updateStockSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Adet", det.Adet);
                            cmd.Parameters.AddWithValue("@IlacID", det.IlacID.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }
    }
}
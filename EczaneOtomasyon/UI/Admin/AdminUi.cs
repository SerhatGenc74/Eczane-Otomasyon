using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EczaneOtomasyon.UI.Admin
{
    internal static class AdminUi
    {
        public static Label CreatePageTitle(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Trebuchet MS", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Padding = new Padding(12, 8, 12, 8)
            };
        }

        public static Label CreateSectionTitle(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Trebuchet MS", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Padding = new Padding(8, 6, 8, 6)
            };
        }

        public static Label CreateFormLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Calibri", 10F),
                ForeColor = Color.FromArgb(51, 65, 85)
            };
        }

        public static TextBox CreateTextBox(bool multiline = false)
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = multiline,
                ScrollBars = multiline ? ScrollBars.Vertical : ScrollBars.None,
                Font = new Font("Calibri", 10F)
            };
        }

        public static ComboBox CreateComboBox(IEnumerable<string> items = null)
        {
            var combo = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Calibri", 10F)
            };

            if (items != null)
            {
                combo.Items.AddRange(items.Cast<object>().ToArray());
                if (combo.Items.Count > 0)
                {
                    combo.SelectedIndex = 0;
                }
            }

            return combo;
        }

        public static Button CreateActionButton(string text, Color backColor)
        {
            var button = new Button
            {
                Text = text,
                Dock = DockStyle.Fill,
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Calibri", 10F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        public static DataGridView CreateGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };
        }

        public static Panel CreateCard(string title, string description, Color accentColor, EventHandler clickHandler)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            var accent = new Panel
            {
                Dock = DockStyle.Left,
                Width = 6,
                BackColor = accentColor
            };

            var titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 34,
                Font = new Font("Trebuchet MS", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Padding = new Padding(12, 8, 12, 0)
            };

            var descLabel = new Label
            {
                Text = description,
                Dock = DockStyle.Fill,
                Font = new Font("Calibri", 10F),
                ForeColor = Color.FromArgb(71, 85, 105),
                Padding = new Padding(12, 4, 12, 8)
            };

            if (clickHandler != null)
            {
                card.Click += clickHandler;
                accent.Click += clickHandler;
                titleLabel.Click += clickHandler;
                descLabel.Click += clickHandler;
            }

            card.Controls.Add(descLabel);
            card.Controls.Add(titleLabel);
            card.Controls.Add(accent);
            return card;
        }
    }
}

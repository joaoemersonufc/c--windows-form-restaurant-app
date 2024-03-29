﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AssaKabrasa.View
{
    public partial class PainelCategoriaAlterar : Form
    {
        public PainelCategoriaAlterar()
        {
            InitializeComponent();
        }

        [STAThread]
        private void S_Click(object sender, EventArgs e)
        {

            Thread td = new Thread(new ThreadStart(this.EscolherImagem));
            td.SetApartmentState(ApartmentState.STA);
            td.IsBackground = true;
            td.Start();
        }


        [STAThread]
        public void EscolherImagem()
        {
            OpenFileDialog TrocarImagem = new OpenFileDialog();
            TrocarImagem.Filter = "Bitmap|*.bmp|Jpegs|*.jpg";

            if (TrocarImagem.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCategoria.ImageLocation = TrocarImagem.FileName;
            }
        }
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
    }
}

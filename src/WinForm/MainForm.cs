using System;
using System.Windows.Forms;
using NHibernateHbmToFluent.Converter;

namespace NHibernateHbmToFluent.WinForm
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			ShowHideErrors(false);
			ShowHideFilesProcessed(false);
		}

		private void _menuFileExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void _btnChooseHbmDirectory_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				_txtHbmDir.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void _btnChooseMapDirectory_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				_txtMapDir.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void ShowHideFilesProcessed(bool visible)
		{
			_txtFilesProcessed.Visible = visible;
			_lblFilesProcessed.Visible = visible;
		}

		private void ShowHideErrors(bool visible)
		{
			_txtErrors.Visible = visible;
			_lblErrors.Visible = visible;
		}

		private void _btnGo_Click(object sender, EventArgs e)
		{
			ShowHideFilesProcessed(true);
			ShowHideErrors(false);
			_txtFilesProcessed.Text = "";
			_txtErrors.Text = "";
			MappingConverter mappingConverter = new MappingConverter(WriteFileName, WriteError);
			mappingConverter.ConvertAll(_txtHbmDir.Text, _txtMapDir.Text, _txtNamespace.Text);
		}


		private void WriteFileName(string message)
		{
			_txtFilesProcessed.Text += message + Environment.NewLine;
		}

		private void WriteError(string message)
		{
			ShowHideErrors(true);
			_txtErrors.Text += message + Environment.NewLine;
		}
	}
}
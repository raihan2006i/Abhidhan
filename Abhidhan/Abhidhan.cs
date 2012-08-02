using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Abhidhan
{
    public partial class Abhidhan : Form
    {
        IntPtr _ClipboardViewerNext;
        string _SearchedWord = "অভিধান";
        string _SearchResult = "Dictionary";
        string _SqlQuery = null;
        bool _EnableClipboardSearch = false;
        bool _EnableBanglaSearch = true;
        bool _EnableEnglishSearch = false;
        bool _ShowSimilarWord = true;
        bool _SearchButtonClicked = false;
        bool _BanglaLanguage = true;
        IniFile _SettingsINI = new IniFile(".\\abhidhan.settings.ini");

        public Abhidhan()
        {
            InitializeComponent();
            try
            {
                _ShowSimilarWord = Convert.ToBoolean(_SettingsINI.IniReadValue("option", "SHOW_SIMILAR_WORD").ToLower());
                _EnableBanglaSearch = Convert.ToBoolean(_SettingsINI.IniReadValue("option", "BANGLA_WORD_SEARCH").ToLower());
                _EnableEnglishSearch = !_EnableBanglaSearch;
                _EnableClipboardSearch = Convert.ToBoolean(_SettingsINI.IniReadValue("option", "SHOW_POP_UP").ToLower());
                _BanglaLanguage = Convert.ToBoolean(_SettingsINI.IniReadValue("language", "BANGLA").ToLower());
                TopMenuSimilarWord.Checked = _ShowSimilarWord;
                TrayMenuSimilarWord.Checked = _ShowSimilarWord;
                TopMenuBanglaWordSearch.Checked = _EnableBanglaSearch;
                TrayMenuBanglaWordSearch.Checked = _EnableBanglaSearch;
                TopMenuEnglishWordSearch.Checked = !_EnableBanglaSearch;
                TrayMenuEnglishWordSearch.Checked = !_EnableBanglaSearch;
                TopMenuShowPopUp.Checked = _EnableClipboardSearch;
                TrayMenuShowPopUp.Checked = _EnableClipboardSearch;
                TopMenuBanglaLanguage.Checked = _BanglaLanguage;
                TopMenuEnglishLanguage.Checked = !_BanglaLanguage;
            }
            catch(Exception settingEx)
            {
                MessageBox.Show(settingEx.Message, "ERROR in abhidhan.settings.ini file.");
            }
        }

        private void Abhidhan_Load(object sender, EventArgs e)
        {
            _ClipboardViewerNext = User32.SetClipboardViewer(this.Handle);
        }

        private void Abhidhan_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                User32.ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
                _SettingsINI.IniWriteValue("option", "SHOW_SIMILAR_WORD", _ShowSimilarWord.ToString().ToUpper());
                _SettingsINI.IniWriteValue("option", "BANGLA_WORD_SEARCH", _EnableBanglaSearch.ToString().ToUpper());
                _SettingsINI.IniWriteValue("option", "SHOW_POP_UP", _EnableClipboardSearch.ToString().ToUpper());
                _SettingsINI.IniWriteValue("language", "BANGLA", _BanglaLanguage.ToString().ToUpper());
                DataAccess._CloseConnection();
            }
            catch(Exception closeEx)
            {
                MessageBox.Show("ERROR:"+closeEx.Message,"Closing Exception");
            }

        }

        private void GetClipboardData()
        {
            //
            // Data on the clipboard uses the 
            // IDataObject interface
            //
            IDataObject iData = new DataObject();

            try
            {
                iData = Clipboard.GetDataObject();
            }
            catch (System.Runtime.InteropServices.ExternalException externEx)
            {
                // Copying a field definition in Access 2002 causes this sometimes?
                //Debug.WriteLine("InteropServices.ExternalException: {0}", externEx.Message);
                return;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return;
            }

            // 
            // Get Text if it is present
            //
            if (iData.GetDataPresent(DataFormats.UnicodeText))
            {
                if (_EnableClipboardSearch)
                {
                    _SearchedWord = (string)iData.GetData(DataFormats.UnicodeText);
                    textBoxSearchKeyWord.Text = _SearchedWord;
                    searchWord(_SearchedWord, _EnableClipboardSearch);
                }
                //ctlClipboardText.Text = (string)iData.GetData(DataFormats.Text);

                //strText = "Text";

                //Debug.WriteLine((string)iData.GetData(DataFormats.Text));
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch ((Msgs)m.Msg)
            {
                //
                // The WM_DRAWCLIPBOARD message is sent to the first window 
                // in the clipboard viewer chain when the content of the 
                // clipboard changes. This enables a clipboard viewer 
                // window to display the new content of the clipboard. 
                //
                case Msgs.WM_DRAWCLIPBOARD:

                    //Debug.WriteLine("WindowProc DRAWCLIPBOARD: " + m.Msg, "WndProc");

                    GetClipboardData();

                    //
                    // Each window that receives the WM_DRAWCLIPBOARD message 
                    // must call the SendMessage function to pass the message 
                    // on to the next window in the clipboard viewer chain.
                    //
                    User32.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    break;


                //
                // The WM_CHANGECBCHAIN message is sent to the first window 
                // in the clipboard viewer chain when a window is being 
                // removed from the chain. 
                //
                case Msgs.WM_CHANGECBCHAIN:
                    //Debug.WriteLine("WM_CHANGECBCHAIN: lParam: " + m.LParam, "WndProc");

                    // When a clipboard viewer window receives the WM_CHANGECBCHAIN message, 
                    // it should call the SendMessage function to pass the message to the 
                    // next window in the chain, unless the next window is the window 
                    // being removed. In this case, the clipboard viewer should save 
                    // the handle specified by the lParam parameter as the next window in the chain. 

                    //
                    // wParam is the Handle to the window being removed from 
                    // the clipboard viewer chain 
                    // lParam is the Handle to the next window in the chain 
                    // following the window being removed. 
                    if (m.WParam == _ClipboardViewerNext)
                    {
                        //
                        // If wParam is the next clipboard viewer then it
                        // is being removed so update pointer to the next
                        // window in the clipboard chain
                        //
                        _ClipboardViewerNext = m.LParam;
                    }
                    else
                    {
                        User32.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    }
                    break;

                default:
                    //
                    // Let the form process the messages that we are
                    // not interested in
                    //
                    base.WndProc(ref m);
                    break;

            }

        }

        private void Abhidhan_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIconTray_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void notifyIconTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIconTray.BalloonTipText = _SearchResult;
                notifyIconTray.BalloonTipTitle = "Result for : " + _SearchedWord;
                notifyIconTray.ShowBalloonTip(40000);
            }
        }

        private void TrayMenuShowPopUp_Click(object sender, EventArgs e)
        {
            TrayMenuShowPopUp.Checked = !TrayMenuShowPopUp.Checked;
            TopMenuShowPopUp.Checked = TrayMenuShowPopUp.Checked;
            _EnableClipboardSearch = TrayMenuShowPopUp.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TopMenuShowPopUp_Click(object sender, EventArgs e)
        {
            TopMenuShowPopUp.Checked = !TopMenuShowPopUp.Checked;
            TrayMenuShowPopUp.Checked = TopMenuShowPopUp.Checked;
            _EnableClipboardSearch = TopMenuShowPopUp.Checked;
        }

        private void minimizeToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            _SearchButtonClicked = !_SearchButtonClicked;
            dataGridViewSimilarWord.DataSource = null;
            if(textBoxSearchKeyWord.Text != "")
            {
                searchWord(textBoxSearchKeyWord.Text, false);
            }
            _SearchButtonClicked = !_SearchButtonClicked;
            dataGridViewSimilarWord.ClearSelection();
        }

        private void TopMenuBanglaWordSearch_Click(object sender, EventArgs e)
        {
            TopMenuBanglaWordSearch.Checked = !TopMenuBanglaWordSearch.Checked;
            TrayMenuBanglaWordSearch.Checked = TopMenuBanglaWordSearch.Checked;
            _EnableBanglaSearch = TopMenuBanglaWordSearch.Checked;
            TopMenuEnglishWordSearch.Checked = !TopMenuBanglaWordSearch.Checked;
            TrayMenuEnglishWordSearch.Checked = TopMenuEnglishWordSearch.Checked;
            _EnableEnglishSearch = TopMenuEnglishWordSearch.Checked;
        }

        private void TopMenuEnglishWordSearch_Click(object sender, EventArgs e)
        {
            TopMenuEnglishWordSearch.Checked = !TopMenuEnglishWordSearch.Checked;
            TrayMenuEnglishWordSearch.Checked = TopMenuEnglishWordSearch.Checked;
            _EnableEnglishSearch = TopMenuEnglishWordSearch.Checked;
            TopMenuBanglaWordSearch.Checked = !TopMenuEnglishWordSearch.Checked;
            TrayMenuBanglaWordSearch.Checked = TopMenuBanglaWordSearch.Checked;
            _EnableBanglaSearch = TopMenuBanglaWordSearch.Checked;
        }

        private void TrayMenuBanglaWordSearch_Click(object sender, EventArgs e)
        {
            TrayMenuBanglaWordSearch.Checked = !TrayMenuBanglaWordSearch.Checked;
            TopMenuBanglaWordSearch.Checked = TrayMenuBanglaWordSearch.Checked;
            _EnableBanglaSearch = TrayMenuBanglaWordSearch.Checked;
            TrayMenuEnglishWordSearch.Checked = !TrayMenuBanglaWordSearch.Checked;
            TopMenuEnglishWordSearch.Checked = TrayMenuEnglishWordSearch.Checked; 
            _EnableEnglishSearch = TrayMenuEnglishWordSearch.Checked;
        }

        private void TrayMenuEnglishWordSearch_Click(object sender, EventArgs e)
        {
            TrayMenuEnglishWordSearch.Checked = !TrayMenuEnglishWordSearch.Checked;
            TopMenuEnglishWordSearch.Checked = TrayMenuEnglishWordSearch.Checked; 
            _EnableEnglishSearch = TrayMenuEnglishWordSearch.Checked;
            TrayMenuBanglaWordSearch.Checked = !TrayMenuEnglishWordSearch.Checked;
            TopMenuBanglaWordSearch.Checked = TrayMenuBanglaWordSearch.Checked;
            _EnableBanglaSearch = TrayMenuBanglaWordSearch.Checked;
        }

        private void searchWord(string word, bool showtooltip)
        {
            if (_EnableEnglishSearch)
            {
                try
                {
                    DataSet Word = new DataSet();
                    _SearchedWord = word;
                    _SqlQuery = "SELECT pos_description, en_lemma, bn_pronunciation, bn_word, explanation, example FROM abhidhan,postag where abhidhan.pos_tag=postag.pos_tag and en_word = \"" + _SearchedWord + "\"";
                    Word = DataAccess.GetDataSet(_SqlQuery);
                    if (Word.Tables[0].Rows.Count > 0)
                    {
                        if(_BanglaLanguage)
                        {
                            textBoxResult.Text = "বাংলা শব্দ : " + Word.Tables[0].Rows[0]["bn_word"].ToString() + "\r\n";
                            textBoxResult.Text += "বাংলা উচ্চারণ : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "ব্যাখ্যা : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "উদাহরণ : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchResult = textBoxResult.Text;
                        }
                        else
                        {
                            textBoxResult.Text = "Bangla Word : " + Word.Tables[0].Rows[0]["bn_word"].ToString() + "\r\n";
                            textBoxResult.Text += "Bangla Pronunciation : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "Explanation : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "Example : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchResult = textBoxResult.Text;
                        }
                    }
                    else
                    {
                        if (_BanglaLanguage)
                        {
                            textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                        }
                        else
                        {
                            textBoxResult.Text = "No Record Found";
                        }
                        _SearchResult = textBoxResult.Text;
                    }
                    if (showtooltip)
                    {
                        notifyIconTray.BalloonTipText = _SearchResult;
                        notifyIconTray.BalloonTipTitle = "Result for : " + _SearchedWord;
                        notifyIconTray.ShowBalloonTip(40000);
                    }
                    if (_ShowSimilarWord)
                    { 
                        _SqlQuery = "SELECT en_word as English,id as ID FROM abhidhan where en_word like \"" + _SearchedWord + "%\"";
                        Word = DataAccess.GetDataSet(_SqlQuery);
                        dataGridViewSimilarWord.DataSource = Word.Tables[0];
                        if (_BanglaLanguage)
                        {
                            dataGridViewSimilarWord.Columns[0].HeaderText = "কাছাকছি শব্দের তালিকা";
                        }
                        else
                        {
                            dataGridViewSimilarWord.Columns[0].HeaderText = "Similar word list";
                        }
                        dataGridViewSimilarWord.Columns[1].Visible = false;
                    }
                }
                catch (OleDbException ex)
                {
                    if (_BanglaLanguage)
                    {
                        textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                    }
                    else
                    {
                        textBoxResult.Text = "No Record Found";
                    }
                }
            }
            else
            {
                try
                {
                    _SearchedWord = word;
                    _SqlQuery = "SELECT pos_description, en_lemma, bn_pronunciation, en_word, explanation, example FROM abhidhan,postag where abhidhan.pos_tag=postag.pos_tag and bn_word = \"" + _SearchedWord + "\"";
                    DataSet Word = new DataSet();
                    Word = DataAccess.GetDataSet(_SqlQuery);
                    if (Word.Tables[0].Rows.Count > 0)
                    {
                        if (_BanglaLanguage)
                        {
                            textBoxResult.Text = "ইংরেজি শব্দ : " + Word.Tables[0].Rows[0]["en_word"].ToString() + "\r\n";
                            textBoxResult.Text += "বাংলা উচ্চারণ : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "ব্যাখ্যা : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "উদাহরণ : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchResult = textBoxResult.Text;
                        }
                        else
                        {
                            textBoxResult.Text = "English Word : " + Word.Tables[0].Rows[0]["en_word"].ToString() + "\r\n";
                            textBoxResult.Text += "Bangla Pronunciation : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "Explanation : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "Example : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchResult = textBoxResult.Text;
                        }
                    }
                    else
                    {
                        if (_BanglaLanguage)
                        {
                            textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                        }
                        else
                        {
                            textBoxResult.Text = "No Record Found";
                        }
                        _SearchResult = textBoxResult.Text;
                    }
                    if (showtooltip)
                    {
                        notifyIconTray.BalloonTipText = _SearchResult;
                        notifyIconTray.BalloonTipTitle = "Result for : " + _SearchedWord;
                        notifyIconTray.ShowBalloonTip(40000);
                    }
                    if (_ShowSimilarWord)
                    {
                        _SqlQuery = "SELECT bn_word as Bangla,id as ID FROM abhidhan where bn_word like \"" + _SearchedWord + "%\"";
                        Word = DataAccess.GetDataSet(_SqlQuery);
                        dataGridViewSimilarWord.DataSource = Word.Tables[0];
                        if (_BanglaLanguage)
                        {
                            dataGridViewSimilarWord.Columns[0].HeaderText = "কাছাকছি শব্দের তালিকা";
                        }
                        else
                        {
                            dataGridViewSimilarWord.Columns[0].HeaderText = "Similar word list";
                        }
                        dataGridViewSimilarWord.Columns[1].Visible = false;
                    }
                }
                catch (OleDbException ex)
                {
                    if (_BanglaLanguage)
                    {
                        textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                    }
                    else
                    {
                        textBoxResult.Text = "No Record Found";
                    }
                }
            }
        }

        private void searchWord(int id, bool showtooltip)
        {
            if (_EnableEnglishSearch)
            {
                try
                {
                    DataSet Word = new DataSet();
                    _SqlQuery = "SELECT en_word,pos_description, en_lemma, bn_pronunciation, bn_word, explanation, example FROM abhidhan,postag where abhidhan.pos_tag=postag.pos_tag and id = " + id + ";";
                    Word = DataAccess.GetDataSet(_SqlQuery);
                    if (Word.Tables[0].Rows.Count > 0)
                    {
                        if (_BanglaLanguage)
                        {
                            textBoxResult.Text = "বাংলা শব্দ : " + Word.Tables[0].Rows[0]["bn_word"].ToString() + "\r\n";
                            textBoxResult.Text += "বাংলা উচ্চারণ : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "ব্যাখ্যা : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "উদাহরণ : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchedWord = Word.Tables[0].Rows[0]["en_word"].ToString();
                            _SearchResult = textBoxResult.Text;
                        }
                        else
                        {
                            textBoxResult.Text = "Bangla Word : " + Word.Tables[0].Rows[0]["bn_word"].ToString() + "\r\n";
                            textBoxResult.Text += "Bangla Pronunciation : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "Explanation : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "Example : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchedWord = Word.Tables[0].Rows[0]["en_word"].ToString();
                            _SearchResult = textBoxResult.Text;
                        }
                        
                    }
                    else
                    {
                        if (_BanglaLanguage)
                        {
                            textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                        }
                        else
                        {
                            textBoxResult.Text = "No Record Found";
                        }
                        _SearchResult = textBoxResult.Text;
                    }
                    if (showtooltip)
                    {
                        notifyIconTray.BalloonTipText = _SearchResult;
                        notifyIconTray.BalloonTipTitle = "Result for : " + _SearchedWord;
                        notifyIconTray.ShowBalloonTip(40000);
                    }
                }
                catch (OleDbException ex)
                {
                    if (_BanglaLanguage)
                    {
                        textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                    }
                    else
                    {
                        textBoxResult.Text = "No Record Found";
                    }
                }
            }
            else
            {
                try
                {
                    _SqlQuery = "SELECT bn_word,pos_description, en_lemma, bn_pronunciation, en_word, explanation, example FROM abhidhan,postag where abhidhan.pos_tag=postag.pos_tag and id = " + id + ";";
                    DataSet Word = new DataSet();
                    Word = DataAccess.GetDataSet(_SqlQuery);
                    if (Word.Tables[0].Rows.Count > 0)
                    {
                        if (_BanglaLanguage)
                        {
                            textBoxResult.Text = "ইংরেজি শব্দ : " + Word.Tables[0].Rows[0]["en_word"].ToString() + "\r\n";
                            textBoxResult.Text += "বাংলা উচ্চারণ : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "ব্যাখ্যা : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "উদাহরণ : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchedWord = Word.Tables[0].Rows[0]["bn_word"].ToString();
                            _SearchResult = textBoxResult.Text;
                        }
                        else
                        {
                            textBoxResult.Text = "English Word : " + Word.Tables[0].Rows[0]["en_word"].ToString() + "\r\n";
                            textBoxResult.Text += "Bangla Pronunciation : " + Word.Tables[0].Rows[0]["bn_pronunciation"].ToString() + "\r\n";
                            textBoxResult.Text += "Explanation : " + Word.Tables[0].Rows[0]["explanation"].ToString() + "\r\n";
                            textBoxResult.Text += "Example : " + Word.Tables[0].Rows[0]["example"].ToString() + "\r\n";
                            textBoxResult.Text += "Part-of-Speech : " + Word.Tables[0].Rows[0]["pos_description"].ToString() + "\r\n";
                            textBoxResult.Text += "English Lemma : " + Word.Tables[0].Rows[0]["en_lemma"].ToString() + "\r\n";
                            _SearchedWord = Word.Tables[0].Rows[0]["bn_word"].ToString();
                            _SearchResult = textBoxResult.Text;
                        }
                        
                    }
                    else
                    {
                        if (_BanglaLanguage)
                        {
                            textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                        }
                        else
                        {
                            textBoxResult.Text = "No Record Found";
                        }
                        _SearchResult = textBoxResult.Text;
                    }
                    if (showtooltip)
                    {
                        notifyIconTray.BalloonTipText = _SearchResult;
                        notifyIconTray.BalloonTipTitle = "Result for : " + _SearchedWord;
                        notifyIconTray.ShowBalloonTip(40000);
                    }
                }
                catch (OleDbException ex)
                {
                    if (_BanglaLanguage)
                    {
                        textBoxResult.Text = "কোন রেকর্ড পাওয়া যায়নি";
                    }
                    else
                    {
                        textBoxResult.Text = "No Record Found";
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxAbhidhan aboutbox = new AboutBoxAbhidhan();
            aboutbox.ShowDialog();
        }

        private void TopMenuSimilarWord_Click(object sender, EventArgs e)
        {
            TopMenuSimilarWord.Checked = !TopMenuSimilarWord.Checked;
            TrayMenuSimilarWord.Checked = TopMenuSimilarWord.Checked;
            _ShowSimilarWord = TopMenuSimilarWord.Checked;
        }

        private void TrayMenuSimilarWord_Click(object sender, EventArgs e)
        {
            TrayMenuSimilarWord.Checked = !TrayMenuSimilarWord.Checked;
            TopMenuSimilarWord.Checked = TrayMenuSimilarWord.Checked;
            _ShowSimilarWord = TrayMenuSimilarWord.Checked;
        }

        private void dataGridViewSimilarWord_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!_SearchButtonClicked)
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    int ID = Convert.ToInt32(dataGridViewSimilarWord.Rows[e.RowIndex].Cells[1].Value.ToString());
                    searchWord(ID, false);
                }
            }
        }

        private void TopMenuSimilarWord_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMenuSimilarWord.Checked)
            {
                notifyIconTray.BalloonTipTitle = "Show Similar words";
                notifyIconTray.BalloonTipText = "Enabled";
                notifyIconTray.ShowBalloonTip(40000);
            }
            else
            {
                notifyIconTray.BalloonTipTitle = "Show Similar words";
                notifyIconTray.BalloonTipText = "Disabled";
                notifyIconTray.ShowBalloonTip(40000);
            }
        }

        private void TopMenuBanglaWordSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMenuBanglaWordSearch.Checked)
            {
                notifyIconTray.BalloonTipTitle = "Bangla word search";
                notifyIconTray.BalloonTipText = "Enabled";
                notifyIconTray.ShowBalloonTip(40000);
                
            }
            else
            {
                notifyIconTray.BalloonTipTitle = "English word search";
                notifyIconTray.BalloonTipText = "Enabled";
                notifyIconTray.ShowBalloonTip(40000);
            }
        }

        private void TopMenuBanglaLanguage_Click(object sender, EventArgs e)
        {
            TopMenuBanglaLanguage.Checked = !TopMenuBanglaLanguage.Checked;
            TopMenuEnglishLanguage.Checked = !TopMenuBanglaLanguage.Checked;
            _BanglaLanguage = TopMenuBanglaLanguage.Checked;
        }

        private void TopMenuEnglishLanguage_Click(object sender, EventArgs e)
        {
            
            TopMenuEnglishLanguage.Checked = !TopMenuEnglishLanguage.Checked;
            TopMenuBanglaLanguage.Checked = !TopMenuEnglishLanguage.Checked;
            _BanglaLanguage = TopMenuBanglaLanguage.Checked;
            
        }
        private void enableBanglaUI()
        {
            this.Text = "অনুবাদ অভিধান";
            buttonSearch.Text = "অনুসন্ধন";
            labelSearchKeyWord.Text = "শব্দঃ";
            groupBoxSearchKeyWord.Text = "অনুসন্ধন";
            groupBoxSearchResult.Text = "ফলাফল";
            groupBoxSimilarWord.Text = "কাছাকছি শব্দ";
            TrayMenuSimilarWord.Text = "কাছাকছি শব্দ দেখাও";
            TrayMenuBanglaWordSearch.Text = "বাংলা শব্দ অনুসন্ধান";
            TrayMenuEnglishWordSearch.Text = "ইংরেজি শব্দ অনুসন্ধান";
            TrayMenuShowPopUp.Text = "Ctrl+C এর জন্য Popup দেখাও";
            TrayMenuShowPopUp.ToolTipText = "Click here to enable pop up search";
            Restore.Text = "System tray -থেকে পুনরুদ্ধার ";
            Restore.ToolTipText = "Click here to restore Abhidhan from system tray";
            CloseApp.Text = "প্রস্থান কর";
            CloseApp.ToolTipText = "Click here to close Abhidhan";
            menuStripTopMenu.Text = "Top Menu";
            fileToolStripMenuItem1.Text = "ফাইল";
            exitToolStripMenuItem.Text = "প্রস্থান কর";
            exitToolStripMenuItem.ToolTipText = "Click here to close Abhidhan";
            fileToolStripMenuItem.Text = "অপশন";
            TopMenuSimilarWord.Text = "কাছাকছি শব্দ দেখাও";
            TopMenuSimilarWord.ToolTipText = "Click here to show Similar word";
            TopMenuBanglaWordSearch.Text = "বাংলা শব্দ অনুসন্ধান";
            TopMenuBanglaWordSearch.ToolTipText = "Click here to enable Bangla word search";
            TopMenuEnglishWordSearch.Text = "ইংরেজি শব্দ অনুসন্ধান";
            TopMenuEnglishWordSearch.ToolTipText = "Click here to enable English word search";
            TopMenuShowPopUp.Text = "Ctrl+C এর জন্য Popup দেখাও";
            TopMenuShowPopUp.ToolTipText = "Click here to enable pop up search";
            minimizeToTrayToolStripMenuItem.Text = "System tray -তে আড়াল কর";
            minimizeToTrayToolStripMenuItem.ToolTipText = "Click here to send Abhidhan to system tray";
            helpToolStripMenuItem.Text = "হেল্প";
            helpToolStripMenuItem.ToolTipText = "About Abhidhan";
            aboutToolStripMenuItem.Text = "পরিচিতি";
            aboutToolStripMenuItem.ToolTipText = "About Abhidhan";
            languageToolStripMenuItem.Text = "ভাষা";
            TopMenuBanglaLanguage.Text = "বাংলা";
            TopMenuEnglishLanguage.Text = "ইংরেজি";
        }
        private void enableEnglishUI()
        {
            this.Text = "Anubad Abhidhan";
            buttonSearch.Text = "Search";
            labelSearchKeyWord.Text = "Word";
            groupBoxSearchKeyWord.Text = "Search";
            groupBoxSearchResult.Text = "Result";
            groupBoxSimilarWord.Text = "Similar word";
            TrayMenuSimilarWord.Text = "Show Similar word";
            TrayMenuBanglaWordSearch.Text = "Bangla word search";
            TrayMenuEnglishWordSearch.Text = "English word search";
            TrayMenuShowPopUp.Text = "Show Popup for Ctrl+C";
            TrayMenuShowPopUp.ToolTipText = "Click here to enable pop up search";
            Restore.Text = "Restore from System tray";
            Restore.ToolTipText = "Click here to restore Abhidhan from system tray";
            CloseApp.Text = "Exit";
            CloseApp.ToolTipText = "Click here to close Abhidhan";
            menuStripTopMenu.Text = "Top Menu";
            fileToolStripMenuItem1.Text = "File";
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.ToolTipText = "Click here to close Abhidhan";
            fileToolStripMenuItem.Text = "Option";
            TopMenuSimilarWord.Text = "Show Similar word";
            TopMenuSimilarWord.ToolTipText = "Click here to show Similar word";
            TopMenuBanglaWordSearch.Text = "Bangla word search";
            TopMenuBanglaWordSearch.ToolTipText = "Click here to enable Bangla word search";
            TopMenuEnglishWordSearch.Text = "English word search";
            TopMenuEnglishWordSearch.ToolTipText = "Click here to enable English word search";
            TopMenuShowPopUp.Text = "Show Popup for Ctrl+C";
            TopMenuShowPopUp.ToolTipText = "Click here to enable pop up search";
            minimizeToTrayToolStripMenuItem.Text = "Minimize to System tray";
            minimizeToTrayToolStripMenuItem.ToolTipText = "Click here to send Abhidhan to system tray";
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.ToolTipText = "About Abhidhan";
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.ToolTipText = "About Abhidhan";
            languageToolStripMenuItem.Text = "Language";
            TopMenuBanglaLanguage.Text = "Bangla";
            TopMenuEnglishLanguage.Text = "English";
        }

        private void TopMenuBanglaLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMenuBanglaLanguage.Checked)
            {
                this.enableBanglaUI();
            }
        }

        private void TopMenuEnglishLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMenuEnglishLanguage.Checked)
            {
                this.enableEnglishUI();
            }
        }

        private void TopMenuShowPopUp_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMenuShowPopUp.Checked)
            {
                notifyIconTray.BalloonTipTitle = "Show Popup for Ctrl+C";
                notifyIconTray.BalloonTipText = "Enabled";
                notifyIconTray.ShowBalloonTip(40000);

            }
            else
            {
                notifyIconTray.BalloonTipTitle = "Show Popup for Ctrl+C";
                notifyIconTray.BalloonTipText = "Disabled";
                notifyIconTray.ShowBalloonTip(40000);
            }
        }

    }
}

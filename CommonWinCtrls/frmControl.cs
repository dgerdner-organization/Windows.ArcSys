using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS2010.CommonWinCtrls
{
    // NOTE: THIS NEEDS TO BE REWRITTEN, DO NOT USE AS IT CURRENTLY IS
    public partial class frmControl : frmDialogBase
    {

        #region Properties
        
        List<ClsFormControl> lstControls = new List<ClsFormControl>();

        int intX = 155;
        int intY = 15;

        #endregion

        #region Constructor

        public frmControl()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Create Controls

        public void ClearControls()
        {
            foreach (ClsFormControl oFC in lstControls)
            {
                oFC.Clear();
            }
        }

        public List<String> GetValues()
        {
            List<String> lstS = new List<String>();

            foreach (ClsFormControl oFC in lstControls)
            {
                lstS.Add(oFC.Value());
            }
            return lstS;
        }

        public bool CreateDatePicker(
                string strLabel)
        {
            ClsFormControl objFC = new ClsFormControl();
            objFC.CreateDatePicker(intX, intY, strLabel, this);
            AddControl(objFC);

            return true;
        }

        //public bool CreateComboBox(
        //        string strLabel,
        //        DataTable DT,
        //        string strDisplayMember,
        //        string strValueMember,
        //        bool AllowBlank)
        //{
        //    ClsFormControl objFC = new ClsFormControl();
        //    objFC.CreateComboBox(intX, intY, strLabel, DT, strDisplayMember, strValueMember, this, AllowBlank);
        //    AddControl(objFC);

        //    return true;
        //}

        //public bool CreateComboBox(
        //string strLabel,
        //List<ComboObject> CO,
        //bool AllowBlank)
        //{
        //    ClsFormControl objFC = new ClsFormControl();
        //    objFC.CreateComboBox(intX, intY, strLabel, CO, this, AllowBlank);
        //    AddControl(objFC);

        //    return true;
        //}

        public bool CreateTextArea(
        string strLabel,
        int MaxChars,
        string strDefault)
        {
            ClsFormControl objFC = new ClsFormControl();
            objFC.CreateTextArea(intX, intY, strLabel, MaxChars, strDefault, this);
            AddControl(objFC);

            return true;
        }

        public bool CreateTextArea(
                string strLabel,
                int MaxChars,
                string strDefault,
                int intWidth,
                int intHeight)
        {
            ClsFormControl objFC = new ClsFormControl();
            objFC.CreateTextArea(intX, intY, strLabel, MaxChars, strDefault, this, intWidth, intHeight);
            AddControl(objFC);

            return true;
        }

        public bool CreateYesNoCombo(
            string strLabel,
            string strDefault)
        {
            ClsFormControl objFC = new ClsFormControl();
            objFC.CreateSimpleCombo(intX, intY, this, strLabel, new string[] { "", "YES", "NO" }, "YES");
            AddControl(objFC);

            return true;
        }

        public bool CreateTextBox(
                string strLabel,
                int MaxChars,
                string strDefault)
        {
            ClsFormControl objFC = new ClsFormControl();
            objFC.CreateTextBox(intX, intY, strLabel, MaxChars, strDefault, this, false, CharacterCasing.Normal);
            AddControl(objFC);

            return true;
        }

        public bool CreateTextBox(
        string strLabel,
        int MaxChars,
        string strDefault,
        Boolean blnPassword,
        CharacterCasing Casing)
        {
            ClsFormControl objFC = new ClsFormControl();
            objFC.CreateTextBox(intX, intY, strLabel, MaxChars, strDefault, this, blnPassword, Casing);
            AddControl(objFC);

            return true;
        }

        #endregion

        #region Private Methods

        private void AddControl(ClsFormControl objFC)
        {
            lstControls.Add(objFC);
            intY = intY + objFC.Height();
            this.Height = (lstControls.Count * objFC.Height()) + 100;
            //	this.Width = 500;
        }

        #endregion

        #region Private Class

        private class ClsFormControl
        {

            #region Fields

            private ucLabel _Label;
            private ucTextBox _TextBox;
            //private ucComboBox _ComboBox;
            private ucComboBox _SimpleCombo;
            private DateTimePicker _DateTimePicker;

            #endregion

            public int Height()
            {
                if (_TextBox != null) return _TextBox.Height;
                //if (_ComboBox != null) return _ComboBox.Height;
                if (_DateTimePicker != null) return _DateTimePicker.Height;
                if (_SimpleCombo != null) return _SimpleCombo.Height;
                return 25;

            }

            public ClsFormControl()
            {
                // Nothing Todo
            }

            public void Clear()
            {
                if (_TextBox != null) _TextBox.Text = string.Empty;
                //if (_ComboBox != null) _ComboBox.Text = string.Empty;
                if (_DateTimePicker != null) { _DateTimePicker.Value = DateTime.Now; _DateTimePicker.Checked = false; }
                if (_SimpleCombo != null) _SimpleCombo.Text = string.Empty;
            }

            public void SetFocus()
            {
                if (_TextBox != null) _TextBox.Focus();
                //if (_ComboBox != null) _ComboBox.Focus();
                if (_DateTimePicker != null) _DateTimePicker.Focus();
                if (_SimpleCombo != null) _SimpleCombo.Focus();

            }

            public string Value()
            {
                if (_TextBox != null) return _TextBox.Text;
                //if (_ComboBox != null) return (_ComboBox.Text == string.Empty) ? string.Empty : _ComboBox.SelectedValue.ToString();
                if (_DateTimePicker != null) return (_DateTimePicker.Checked == false) ? string.Empty : _DateTimePicker.Value.ToShortDateString();
                if (_SimpleCombo != null) return _SimpleCombo.Text;
                return string.Empty;
            }

            public void CreateDatePicker(
                int intX,
                int intY,
                string strLabel,
                Form frmX)
            {
                _DateTimePicker = new DateTimePicker();
                _DateTimePicker.Location = new System.Drawing.Point(intX, intY);
                _DateTimePicker.Size = new System.Drawing.Size(300, 20);
                _DateTimePicker.Parent = frmX;
                _DateTimePicker.ShowCheckBox = true;
                _DateTimePicker.Format = DateTimePickerFormat.Short;

                CreateLabel(intX, intY, strLabel, frmX);
            }


            public void CreateSimpleCombo(
                int intX,
                int intY,
                Form frmX,
                string strLabel,
                string[] strArray,
                string strDefault)
            {
                _SimpleCombo = new ucComboBox();
                _SimpleCombo.Location = new System.Drawing.Point(intX, intY);
                _SimpleCombo.Size = new System.Drawing.Size(300, 20);
                _SimpleCombo.DropDownStyle = ComboBoxStyle.DropDownList;
                _SimpleCombo.Parent = frmX;

                foreach (string o in strArray)
                {
                    _SimpleCombo.Items.Add(o);
                }
                _SimpleCombo.Text = strDefault;
                _SimpleCombo.SelectedText = strDefault;
                _SimpleCombo.SelectedValue = strDefault;

                CreateLabel(intX, intY, strLabel, frmX);

            }


            //public void CreateComboBox(
            //    int intX,
            //    int intY,
            //    string strLabel,
            //    List<ComboObject> CO,
            //    Form frmX,
            //    bool AllowBlank)
            //{

            //    if (AllowBlank) ComboObject.AddComboObject(CO, string.Empty, string.Empty);

            //    _ComboBox = new ucComboBox();
            //    _ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //    _ComboBox.DataSource = CO;
            //    _ComboBox.DisplayMember = "DisplayMember";
            //    _ComboBox.ValueMember = "ValueMember";
            //    _ComboBox.Location = new System.Drawing.Point(intX, intY);
            //    _ComboBox.Size = new System.Drawing.Size(300, 20);
            //    _ComboBox.Parent = frmX;

            //    CreateLabel(intX, intY, strLabel, frmX);
            //}

            //public void CreateComboBox(
            //    int intX,
            //    int intY,
            //    string strLabel,
            //    DataTable DT,
            //    string strDisplayMember,
            //    string strValueMember,
            //    Form frmX,
            //    bool AllowBlank)
            //{

            //    if (AllowBlank) DT.Rows.Add(DT.NewRow());

            //    _ComboBox = new ucComboBox();
            //    _ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //    _ComboBox.DataSource = DT;
            //    _ComboBox.DisplayMember = strDisplayMember;
            //    _ComboBox.ValueMember = strValueMember;
            //    _ComboBox.Location = new System.Drawing.Point(intX, intY);
            //    _ComboBox.Size = new System.Drawing.Size(300, 20);
            //    _ComboBox.Parent = frmX;

            //    CreateLabel(intX, intY, strLabel, frmX);
            //}


            public void CreateTextBox(
                int intX,
                int intY,
                string strLabel,
                int MaxChars,
                string strDefault,
                Form frmX,
                Boolean blnPassword,
                CharacterCasing Casing)
            {
                _TextBox = new ucTextBox();
                _TextBox.Location = new System.Drawing.Point(intX, intY);
                _TextBox.Size = new System.Drawing.Size(300, 20);
                _TextBox.Parent = frmX;
                _TextBox.MaxLength = MaxChars;
                _TextBox.CharacterCasing = CharacterCasing.Normal;
                _TextBox.Text = strDefault;
                _TextBox.CharacterCasing = Casing;
                if (blnPassword) _TextBox.PasswordChar = '*';

                CreateLabel(intX, intY, strLabel, frmX);
            }

            public void CreateTextArea(
                int intX,
                int intY,
                string strLabel,
                int MaxChars,
                string strDefault,
                Form frmX)
            {
                CreateTextArea(intX, intY, strLabel, MaxChars, strDefault, frmX, 300, 200);

            }

            public void CreateTextArea(
                int intX,
                int intY,
                string strLabel,
                int MaxChars,
                string strDefault,
                Form frmX,
                int intWidth,
                int intHeight)
            {
                _TextBox = new ucTextBox();
                _TextBox.Location = new System.Drawing.Point(intX, intY);
                _TextBox.Size = new System.Drawing.Size(intWidth, intHeight);
                _TextBox.Parent = frmX;
                _TextBox.Multiline = true;
                _TextBox.MaxLength = MaxChars;
                _TextBox.Text = strDefault;
                _TextBox.ScrollBars = ScrollBars.Vertical;
                _TextBox.CharacterCasing = CharacterCasing.Normal;

                frmX.Width = frmX.Width + ((intWidth - 300));
                frmX.Height = frmX.Height + (intHeight - 200);

                CreateLabel(intX, intY, strLabel, frmX);
            }

            private void CreateLabel(
                int intX,
                int intY,
                string strLabel,
                Form frmX)
            {
                _Label = new ucLabel();
                _Label.Location = new System.Drawing.Point((intX - 155), intY);
                _Label.Size = new System.Drawing.Size(150, 20);
                _Label.Parent = frmX;
                _Label.Text = strLabel;
                _Label.AutoSize = false;
                _Label.TextAlign = ContentAlignment.MiddleRight;


            }
        }

        #endregion

        #region Event Handlers

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        private void frmControl_Shown(object sender, EventArgs e)
        {
            if (lstControls.Count > 0) lstControls[0].SetFocus();
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace DataLayoutControl_FieldRetrieve {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            BindingSource personBindingSource = new BindingSource();
            personBindingSource.DataSource = typeof(Person);
            personBindingSource.AddNew();

            dataLayoutControl1.FieldRetrieving += dataLayoutControl1_FieldRetrieving;
            dataLayoutControl1.FieldRetrieved += dataLayoutControl1_FieldRetrieved;
            dataLayoutControl1.DataSource = personBindingSource;
            
            dataLayoutControl1.RetrieveFields();
        }

        void dataLayoutControl1_FieldRetrieving(object sender, DevExpress.XtraDataLayout.FieldRetrievingEventArgs e) {
            if (e.FieldName == "ZipCode") 
                e.EditorType = typeof(ComboBoxEdit);
            e.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            e.Handled = true;
        }

        void dataLayoutControl1_FieldRetrieved(object sender, DevExpress.XtraDataLayout.FieldRetrievedEventArgs e) {
            if (e.FieldName == "FirstName" || e.FieldName == "LastName") {
                e.Control.BackColor = Color.GreenYellow;
            }
            if (e.FieldName == "ZipCode") {
                RepositoryItemComboBox riComboBox = e.RepositoryItem as RepositoryItemComboBox;
                riComboBox.TextEditStyle = TextEditStyles.DisableTextEditor;
                riComboBox.Items.Add("20505");
                riComboBox.Items.Add("20506");
                riComboBox.Items.Add("20507");
                riComboBox.Items.Add("20508");
                riComboBox.Items.Add("20509");
            }
        }
    }

    public class Person {
        [Display(GroupName = "<GroupName->")]
        public string FirstName { get; set; }
        [Display(GroupName = "<GroupName->")]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        [Display(GroupName = "<GroupPhone->")]
        public string Phone { get; set; }
        [Display(GroupName = "<GroupPhone->")]
        public string Email { get; set; }
        [Display(GroupName = "Address")]
        public string City { get; set; }
        [Display(GroupName = "Address")]
        public string ZipCode { get; set; }
    }


}

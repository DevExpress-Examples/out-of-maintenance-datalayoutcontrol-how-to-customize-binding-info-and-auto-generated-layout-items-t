Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository

Namespace DataLayoutControl_FieldRetrieve
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim personBindingSource As New BindingSource()
            personBindingSource.DataSource = GetType(Person)
            personBindingSource.AddNew()

            AddHandler dataLayoutControl1.FieldRetrieving, AddressOf dataLayoutControl1_FieldRetrieving
            AddHandler dataLayoutControl1.FieldRetrieved, AddressOf dataLayoutControl1_FieldRetrieved
            dataLayoutControl1.DataSource = personBindingSource

            dataLayoutControl1.RetrieveFields()
        End Sub

        Private Sub dataLayoutControl1_FieldRetrieving(ByVal sender As Object, ByVal e As DevExpress.XtraDataLayout.FieldRetrievingEventArgs)
            If e.FieldName = "ZipCode" Then
                e.EditorType = GetType(ComboBoxEdit)
            End If
            e.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            e.Handled = True
        End Sub

        Private Sub dataLayoutControl1_FieldRetrieved(ByVal sender As Object, ByVal e As DevExpress.XtraDataLayout.FieldRetrievedEventArgs)
            If e.FieldName = "FirstName" OrElse e.FieldName = "LastName" Then
                e.Control.BackColor = Color.GreenYellow
            End If
            If e.FieldName = "ZipCode" Then
                Dim riComboBox As RepositoryItemComboBox = TryCast(e.RepositoryItem, RepositoryItemComboBox)
                riComboBox.TextEditStyle = TextEditStyles.DisableTextEditor
                riComboBox.Items.Add("20505")
                riComboBox.Items.Add("20506")
                riComboBox.Items.Add("20507")
                riComboBox.Items.Add("20508")
                riComboBox.Items.Add("20509")
            End If
        End Sub
    End Class

    Public Class Person
        <Display(GroupName := "<GroupName->")> _
        Public Property FirstName() As String
        <Display(GroupName := "<GroupName->")> _
        Public Property LastName() As String
        Public ReadOnly Property FullName() As String
            Get
                Return FirstName & " " & LastName
            End Get
        End Property
        <Display(GroupName := "<GroupPhone->")> _
        Public Property Phone() As String
        <Display(GroupName := "<GroupPhone->")> _
        Public Property Email() As String
        <Display(GroupName := "Address")> _
        Public Property City() As String
        <Display(GroupName := "Address")> _
        Public Property ZipCode() As String
    End Class


End Namespace

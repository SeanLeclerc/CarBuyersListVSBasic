Public Class Form1
    Public Champs As New ArrayList()

    Public Structure ProprioVehicules
        Dim Province As String
        Dim ville As String
        Dim NoMembre As Integer
        Dim Nom As String
        Dim Prenom As String
        Dim Adresse As String
        Dim CodePostal As String
        Dim Notelephone As String
        Dim Courriel As String
        Dim Langue As String
        Dim DateNaissance As String
        Dim Marque As String
        Dim Modele As String
    End Structure

    'Avec la collection SortedList, les clés sont triées automatiquement
    'Public FichePays As New SortedList(Of Integer, ProprioVehicules)
    Public FichePays As New SortedList(Of String, ProprioVehicules)

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim NodeKey As String = ""
        Dim categorieMarque As String = ""
        Dim PreviousCategorieMarque As String = ""
        Dim ItemMembre As String = ""

        Button4_Click(sender, e)

        For Each NodeKey In FichePays.Keys
            'Extrire données de la collection et stocker données dans la structure
            Dim DonneesList As New ProprioVehicules
            DonneesList.Province = FichePays(NodeKey).Province
            DonneesList.ville = FichePays(NodeKey).ville
            DonneesList.NoMembre = FichePays(NodeKey).NoMembre
            DonneesList.Nom = FichePays(NodeKey).Nom
            DonneesList.Prenom = FichePays(NodeKey).Prenom
            DonneesList.Adresse = FichePays(NodeKey).Adresse
            DonneesList.Province = FichePays(NodeKey).Province
            DonneesList.CodePostal = FichePays(NodeKey).CodePostal
            DonneesList.Notelephone = FichePays(NodeKey).Notelephone
            DonneesList.Courriel = FichePays(NodeKey).Courriel
            DonneesList.Langue = FichePays(NodeKey).Langue
            DonneesList.DateNaissance = FichePays(NodeKey).DateNaissance
            DonneesList.Modele = FichePays(NodeKey).Modele


            DecoderNodeKey(NodeKey)
            Dim nCategorie As New ListViewGroup
            Dim nMembre As New ListViewItem
            categorieMarque = Champs(0)
            ItemMembre = CStr(Champs(1))

            ListView2.Columns.Clear()
            ListView2.Columns.Add("No", 25, HorizontalAlignment.Left)
            ListView2.Columns.Add("Nom", 80, HorizontalAlignment.Left)
            ListView2.Columns.Add("Prénom", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("Adresse", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("Ville", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("Province", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("Code Postal", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("No Telephone", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("Courriel", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("Langue", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("Date naissance", 60, HorizontalAlignment.Left)
            ListView2.Columns.Add("modele", 60, HorizontalAlignment.Left)

            If categorieMarque <> PreviousCategorieMarque Then
                nCategorie.Header = categorieMarque
                nCategorie.Name = categorieMarque
                ListView2.Groups.Add(nCategorie)
                nMembre.Text = ItemMembre
                nMembre.Tag = NodeKey
                nMembre.Group = ListView2.Groups(categorieMarque)
                nMembre.SubItems.Add(DonneesList.Nom)
                nMembre.SubItems.Add(DonneesList.Prenom)
                nMembre.SubItems.Add(DonneesList.Adresse)
                nMembre.SubItems.Add(DonneesList.ville)
                nMembre.SubItems.Add(DonneesList.Province)
                nMembre.SubItems.Add(DonneesList.CodePostal)
                nMembre.SubItems.Add(DonneesList.Notelephone)
                nMembre.SubItems.Add(DonneesList.Courriel)
                nMembre.SubItems.Add(DonneesList.Langue)
                nMembre.SubItems.Add(DonneesList.DateNaissance)
                nMembre.SubItems.Add(DonneesList.Modele)
                ListView2.Items.Add(nMembre)
                PreviousCategorieMarque = categorieMarque

            Else
                nMembre.Text = ItemMembre
                nMembre.Tag = NodeKey
                nMembre.Group = ListView2.Groups(categorieMarque)
                nMembre.SubItems.Add(DonneesList.Nom)
                nMembre.SubItems.Add(DonneesList.Prenom)
                nMembre.SubItems.Add(DonneesList.Adresse)
                nMembre.SubItems.Add(DonneesList.ville)
                nMembre.SubItems.Add(DonneesList.Province)
                nMembre.SubItems.Add(DonneesList.CodePostal)
                nMembre.SubItems.Add(DonneesList.Notelephone)
                nMembre.SubItems.Add(DonneesList.Courriel)
                nMembre.SubItems.Add(DonneesList.Langue)
                nMembre.SubItems.Add(DonneesList.DateNaissance)
                nMembre.SubItems.Add(DonneesList.Modele)
                ListView2.Items.Add(nMembre)
            End If
        Next NodeKey
        ListView2.View = View.Details
        ListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView2.GridLines = True
        ListView2.FullRowSelect = True
        ListView2.LabelEdit = True
        ListView2.MultiSelect = True
        ListView2.Sorting = SortOrder.Ascending

    End Sub
    Public Sub DecoderNodeKey(ByVal keynode As String)
        Champs.Clear()
        Dim positionDelimiteur As Integer
        Do
            positionDelimiteur = InStr(keynode, "\")
            Champs.Add(Microsoft.VisualBasic.Left(keynode, positionDelimiteur - 1))
            keynode = Microsoft.VisualBasic.Right(keynode, Len(keynode) - positionDelimiteur)
        Loop Until InStr(keynode, "\") = 0
        Champs.Add(keynode)
    End Sub

    Public Sub ChargerDansCollection()
        Dim cle As String
        Dim Pays As New ProprioVehicules
        cle = Champs(11) & "\" & CStr(Champs(2))
        Pays.Province = Champs(0)
        Pays.ville = Champs(1)
        Pays.NoMembre = Champs(2)
        Pays.Nom = Champs(3)
        Pays.Prenom = Champs(4)
        Pays.Adresse = Champs(5)
        Pays.CodePostal = Champs(6)
        Pays.Notelephone = Champs(7)
        Pays.Courriel = Champs(8)
        Pays.Langue = Champs(9)
        Pays.DateNaissance = Champs(10)
        Pays.Marque = Champs(11)
        Pays.Modele = Champs(12)

        If Not FichePays.ContainsKey(cle) Then
            FichePays.Add(cle, Pays)
        End If
    End Sub
    Private Sub ExtraireChampsDunEnregistrementFichierdelimite(ByVal chaine As String)
        Champs.Clear()
        Dim positionDelimiteur As Integer
        Do
            positionDelimiteur = InStr(chaine, "|")
            Champs.Add(Microsoft.VisualBasic.Left(chaine, positionDelimiteur - 1))
            chaine = Microsoft.VisualBasic.Right(chaine, Len(chaine) - positionDelimiteur)
        Loop Until InStr(chaine, "|") = 0
        Champs.Add(chaine)
    End Sub

    Public Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim lineNo As Integer = 0
        Dim fileReader As System.IO.StreamReader
        Dim stringReader As String
        fileReader = My.Computer.FileSystem.OpenTextFileReader("..\..\..\Exercice022.txt")
        While Not fileReader.EndOfStream
            stringReader = fileReader.ReadLine()
            lineNo = lineNo + 1
            'MsgBox(CStr(lineNo) & " : " & stringReader)
            ExtraireChampsDunEnregistrementFichierdelimite(stringReader)
            ChargerDansCollection()
        End While
        fileReader.Close()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Afficher la vue détails
        ListView2.View = View.Details
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Afficher la vue  liste
        ListView2.View = View.List
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Afficher la vue avec des petites icönes
        ListView2.View = View.SmallIcon
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub
End Class



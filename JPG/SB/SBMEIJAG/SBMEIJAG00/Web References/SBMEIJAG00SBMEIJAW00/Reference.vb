﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'このソース コードは Microsoft.VSDesigner、バージョン 4.0.30319.42000 によって自動生成されました。
'
Namespace SBMEIJAG00SBMEIJAW00
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="SBMEIJAW00Soap", [Namespace]:="http://tempuri.org/SBMEIJAW00/Service1")>  _
    Partial Public Class SBMEIJAW00
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private mChkkisofileOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mChkkisofileCSVOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mChkLTOSfileOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mChkLTOSfileCSVOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mReadkisofileOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mReadkisofileCSVOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mReadLTOSfileOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mReadLTOSfileCSVOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://knapsv/JPGAP/SB/SBMEIJAW/SBMEIJAW00/SBMEIJAW00.asmx"
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event mChkkisofileCompleted As mChkkisofileCompletedEventHandler
        
        '''<remarks/>
        Public Event mChkkisofileCSVCompleted As mChkkisofileCSVCompletedEventHandler
        
        '''<remarks/>
        Public Event mChkLTOSfileCompleted As mChkLTOSfileCompletedEventHandler
        
        '''<remarks/>
        Public Event mChkLTOSfileCSVCompleted As mChkLTOSfileCSVCompletedEventHandler
        
        '''<remarks/>
        Public Event mReadkisofileCompleted As mReadkisofileCompletedEventHandler
        
        '''<remarks/>
        Public Event mReadkisofileCSVCompleted As mReadkisofileCSVCompletedEventHandler
        
        '''<remarks/>
        Public Event mReadLTOSfileCompleted As mReadLTOSfileCompletedEventHandler
        
        '''<remarks/>
        Public Event mReadLTOSfileCSVCompleted As mReadLTOSfileCSVCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mChkkisofile", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mChkkisofile(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String
            Dim results() As Object = Me.Invoke("mChkkisofile", New Object() {pstrFilePath, pstrDATAshu})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmChkkisofile(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mChkkisofile", New Object() {pstrFilePath, pstrDATAshu}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmChkkisofile(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mChkkisofileAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String)
            Me.mChkkisofileAsync(pstrFilePath, pstrDATAshu, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mChkkisofileAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal userState As Object)
            If (Me.mChkkisofileOperationCompleted Is Nothing) Then
                Me.mChkkisofileOperationCompleted = AddressOf Me.OnmChkkisofileOperationCompleted
            End If
            Me.InvokeAsync("mChkkisofile", New Object() {pstrFilePath, pstrDATAshu}, Me.mChkkisofileOperationCompleted, userState)
        End Sub
        
        Private Sub OnmChkkisofileOperationCompleted(ByVal arg As Object)
            If (Not (Me.mChkkisofileCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mChkkisofileCompleted(Me, New mChkkisofileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mChkkisofileCSV", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mChkkisofileCSV(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String
            Dim results() As Object = Me.Invoke("mChkkisofileCSV", New Object() {pstrFilePath, pstrDATAshu})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmChkkisofileCSV(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mChkkisofileCSV", New Object() {pstrFilePath, pstrDATAshu}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmChkkisofileCSV(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mChkkisofileCSVAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String)
            Me.mChkkisofileCSVAsync(pstrFilePath, pstrDATAshu, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mChkkisofileCSVAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal userState As Object)
            If (Me.mChkkisofileCSVOperationCompleted Is Nothing) Then
                Me.mChkkisofileCSVOperationCompleted = AddressOf Me.OnmChkkisofileCSVOperationCompleted
            End If
            Me.InvokeAsync("mChkkisofileCSV", New Object() {pstrFilePath, pstrDATAshu}, Me.mChkkisofileCSVOperationCompleted, userState)
        End Sub
        
        Private Sub OnmChkkisofileCSVOperationCompleted(ByVal arg As Object)
            If (Not (Me.mChkkisofileCSVCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mChkkisofileCSVCompleted(Me, New mChkkisofileCSVCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mChkLTOSfile", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mChkLTOSfile(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String
            Dim results() As Object = Me.Invoke("mChkLTOSfile", New Object() {pstrFilePath, pstrDATAshu})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmChkLTOSfile(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mChkLTOSfile", New Object() {pstrFilePath, pstrDATAshu}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmChkLTOSfile(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mChkLTOSfileAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String)
            Me.mChkLTOSfileAsync(pstrFilePath, pstrDATAshu, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mChkLTOSfileAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal userState As Object)
            If (Me.mChkLTOSfileOperationCompleted Is Nothing) Then
                Me.mChkLTOSfileOperationCompleted = AddressOf Me.OnmChkLTOSfileOperationCompleted
            End If
            Me.InvokeAsync("mChkLTOSfile", New Object() {pstrFilePath, pstrDATAshu}, Me.mChkLTOSfileOperationCompleted, userState)
        End Sub
        
        Private Sub OnmChkLTOSfileOperationCompleted(ByVal arg As Object)
            If (Not (Me.mChkLTOSfileCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mChkLTOSfileCompleted(Me, New mChkLTOSfileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mChkLTOSfileCSV", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mChkLTOSfileCSV(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String
            Dim results() As Object = Me.Invoke("mChkLTOSfileCSV", New Object() {pstrFilePath, pstrDATAshu})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmChkLTOSfileCSV(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mChkLTOSfileCSV", New Object() {pstrFilePath, pstrDATAshu}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmChkLTOSfileCSV(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mChkLTOSfileCSVAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String)
            Me.mChkLTOSfileCSVAsync(pstrFilePath, pstrDATAshu, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mChkLTOSfileCSVAsync(ByVal pstrFilePath As String, ByVal pstrDATAshu As String, ByVal userState As Object)
            If (Me.mChkLTOSfileCSVOperationCompleted Is Nothing) Then
                Me.mChkLTOSfileCSVOperationCompleted = AddressOf Me.OnmChkLTOSfileCSVOperationCompleted
            End If
            Me.InvokeAsync("mChkLTOSfileCSV", New Object() {pstrFilePath, pstrDATAshu}, Me.mChkLTOSfileCSVOperationCompleted, userState)
        End Sub
        
        Private Sub OnmChkLTOSfileCSVOperationCompleted(ByVal arg As Object)
            If (Not (Me.mChkLTOSfileCSVCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mChkLTOSfileCSVCompleted(Me, New mChkLTOSfileCSVCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mReadkisofile", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mReadkisofile(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String
            Dim results() As Object = Me.Invoke("mReadkisofile", New Object() {pstrFilePath, pstrNendo, pstrUser})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmReadkisofile(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mReadkisofile", New Object() {pstrFilePath, pstrNendo, pstrUser}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmReadkisofile(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mReadkisofileAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String)
            Me.mReadkisofileAsync(pstrFilePath, pstrNendo, pstrUser, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mReadkisofileAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal userState As Object)
            If (Me.mReadkisofileOperationCompleted Is Nothing) Then
                Me.mReadkisofileOperationCompleted = AddressOf Me.OnmReadkisofileOperationCompleted
            End If
            Me.InvokeAsync("mReadkisofile", New Object() {pstrFilePath, pstrNendo, pstrUser}, Me.mReadkisofileOperationCompleted, userState)
        End Sub
        
        Private Sub OnmReadkisofileOperationCompleted(ByVal arg As Object)
            If (Not (Me.mReadkisofileCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mReadkisofileCompleted(Me, New mReadkisofileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mReadkisofileCSV", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mReadkisofileCSV(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String
            Dim results() As Object = Me.Invoke("mReadkisofileCSV", New Object() {pstrFilePath, pstrNendo, pstrUser})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmReadkisofileCSV(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mReadkisofileCSV", New Object() {pstrFilePath, pstrNendo, pstrUser}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmReadkisofileCSV(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mReadkisofileCSVAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String)
            Me.mReadkisofileCSVAsync(pstrFilePath, pstrNendo, pstrUser, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mReadkisofileCSVAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal userState As Object)
            If (Me.mReadkisofileCSVOperationCompleted Is Nothing) Then
                Me.mReadkisofileCSVOperationCompleted = AddressOf Me.OnmReadkisofileCSVOperationCompleted
            End If
            Me.InvokeAsync("mReadkisofileCSV", New Object() {pstrFilePath, pstrNendo, pstrUser}, Me.mReadkisofileCSVOperationCompleted, userState)
        End Sub
        
        Private Sub OnmReadkisofileCSVOperationCompleted(ByVal arg As Object)
            If (Not (Me.mReadkisofileCSVCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mReadkisofileCSVCompleted(Me, New mReadkisofileCSVCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mReadLTOSfile", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mReadLTOSfile(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String
            Dim results() As Object = Me.Invoke("mReadLTOSfile", New Object() {pstrFilePath, pstrNendo, pstrUser})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmReadLTOSfile(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mReadLTOSfile", New Object() {pstrFilePath, pstrNendo, pstrUser}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmReadLTOSfile(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mReadLTOSfileAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String)
            Me.mReadLTOSfileAsync(pstrFilePath, pstrNendo, pstrUser, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mReadLTOSfileAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal userState As Object)
            If (Me.mReadLTOSfileOperationCompleted Is Nothing) Then
                Me.mReadLTOSfileOperationCompleted = AddressOf Me.OnmReadLTOSfileOperationCompleted
            End If
            Me.InvokeAsync("mReadLTOSfile", New Object() {pstrFilePath, pstrNendo, pstrUser}, Me.mReadLTOSfileOperationCompleted, userState)
        End Sub
        
        Private Sub OnmReadLTOSfileOperationCompleted(ByVal arg As Object)
            If (Not (Me.mReadLTOSfileCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mReadLTOSfileCompleted(Me, New mReadLTOSfileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SBMEIJAW00/Service1/mReadLTOSfileCSV", RequestNamespace:="http://tempuri.org/SBMEIJAW00/Service1", ResponseNamespace:="http://tempuri.org/SBMEIJAW00/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mReadLTOSfileCSV(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String
            Dim results() As Object = Me.Invoke("mReadLTOSfileCSV", New Object() {pstrFilePath, pstrNendo, pstrUser})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmReadLTOSfileCSV(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mReadLTOSfileCSV", New Object() {pstrFilePath, pstrNendo, pstrUser}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmReadLTOSfileCSV(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mReadLTOSfileCSVAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String)
            Me.mReadLTOSfileCSVAsync(pstrFilePath, pstrNendo, pstrUser, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mReadLTOSfileCSVAsync(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String, ByVal userState As Object)
            If (Me.mReadLTOSfileCSVOperationCompleted Is Nothing) Then
                Me.mReadLTOSfileCSVOperationCompleted = AddressOf Me.OnmReadLTOSfileCSVOperationCompleted
            End If
            Me.InvokeAsync("mReadLTOSfileCSV", New Object() {pstrFilePath, pstrNendo, pstrUser}, Me.mReadLTOSfileCSVOperationCompleted, userState)
        End Sub
        
        Private Sub OnmReadLTOSfileCSVOperationCompleted(ByVal arg As Object)
            If (Not (Me.mReadLTOSfileCSVCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mReadLTOSfileCSVCompleted(Me, New mReadLTOSfileCSVCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mChkkisofileCompletedEventHandler(ByVal sender As Object, ByVal e As mChkkisofileCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mChkkisofileCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mChkkisofileCSVCompletedEventHandler(ByVal sender As Object, ByVal e As mChkkisofileCSVCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mChkkisofileCSVCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mChkLTOSfileCompletedEventHandler(ByVal sender As Object, ByVal e As mChkLTOSfileCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mChkLTOSfileCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mChkLTOSfileCSVCompletedEventHandler(ByVal sender As Object, ByVal e As mChkLTOSfileCSVCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mChkLTOSfileCSVCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mReadkisofileCompletedEventHandler(ByVal sender As Object, ByVal e As mReadkisofileCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mReadkisofileCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mReadkisofileCSVCompletedEventHandler(ByVal sender As Object, ByVal e As mReadkisofileCSVCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mReadkisofileCSVCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mReadLTOSfileCompletedEventHandler(ByVal sender As Object, ByVal e As mReadLTOSfileCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mReadLTOSfileCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mReadLTOSfileCSVCompletedEventHandler(ByVal sender As Object, ByVal e As mReadLTOSfileCSVCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mReadLTOSfileCSVCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace

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
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'このソース コードは Microsoft.VSDesigner、バージョン 4.0.30319.42000 によって自動生成されました。
'
Namespace MSJIGJAG00CCSQL
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="CSQLSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class CSQL
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private mGetDataClearRowOperationCompleted As System.Threading.SendOrPostCallback
        
        Private mGetDataOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.MSJIGJAG00.My.MySettings.Default.MSJIGJAG00_MSJIGJAG00CCSQL_CSQL
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
        Public Event mGetDataClearRowCompleted As mGetDataClearRowCompletedEventHandler
        
        '''<remarks/>
        Public Event mGetDataCompleted As mGetDataCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/mGetDataClearRow", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mGetDataClearRow(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean, ByVal pClearRow As Boolean) As System.Data.DataSet
            Dim results() As Object = Me.Invoke("mGetDataClearRow", New Object() {pSQL, pDs, pNoDatRec, pClearRow})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Function BeginmGetDataClearRow(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean, ByVal pClearRow As Boolean, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mGetDataClearRow", New Object() {pSQL, pDs, pNoDatRec, pClearRow}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmGetDataClearRow(ByVal asyncResult As System.IAsyncResult) As System.Data.DataSet
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mGetDataClearRowAsync(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean, ByVal pClearRow As Boolean)
            Me.mGetDataClearRowAsync(pSQL, pDs, pNoDatRec, pClearRow, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mGetDataClearRowAsync(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean, ByVal pClearRow As Boolean, ByVal userState As Object)
            If (Me.mGetDataClearRowOperationCompleted Is Nothing) Then
                Me.mGetDataClearRowOperationCompleted = AddressOf Me.OnmGetDataClearRowOperationCompleted
            End If
            Me.InvokeAsync("mGetDataClearRow", New Object() {pSQL, pDs, pNoDatRec, pClearRow}, Me.mGetDataClearRowOperationCompleted, userState)
        End Sub
        
        Private Sub OnmGetDataClearRowOperationCompleted(ByVal arg As Object)
            If (Not (Me.mGetDataClearRowCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mGetDataClearRowCompleted(Me, New mGetDataClearRowCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/mGetData", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mGetData(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean) As System.Data.DataSet
            Dim results() As Object = Me.Invoke("mGetData", New Object() {pSQL, pDs, pNoDatRec})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Function BeginmGetData(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mGetData", New Object() {pSQL, pDs, pNoDatRec}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmGetData(ByVal asyncResult As System.IAsyncResult) As System.Data.DataSet
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mGetDataAsync(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean)
            Me.mGetDataAsync(pSQL, pDs, pNoDatRec, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mGetDataAsync(ByVal pSQL As String, ByVal pDs As System.Data.DataSet, ByVal pNoDatRec As Boolean, ByVal userState As Object)
            If (Me.mGetDataOperationCompleted Is Nothing) Then
                Me.mGetDataOperationCompleted = AddressOf Me.OnmGetDataOperationCompleted
            End If
            Me.InvokeAsync("mGetData", New Object() {pSQL, pDs, pNoDatRec}, Me.mGetDataOperationCompleted, userState)
        End Sub
        
        Private Sub OnmGetDataOperationCompleted(ByVal arg As Object)
            If (Not (Me.mGetDataCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mGetDataCompleted(Me, New mGetDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub mGetDataClearRowCompletedEventHandler(ByVal sender As Object, ByVal e As mGetDataClearRowCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mGetDataClearRowCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataSet
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataSet)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0")>  _
    Public Delegate Sub mGetDataCompletedEventHandler(ByVal sender As Object, ByVal e As mGetDataCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mGetDataCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataSet
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataSet)
            End Get
        End Property
    End Class
End Namespace

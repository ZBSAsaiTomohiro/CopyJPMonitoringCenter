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
Namespace SYDIKJAG00SYDIKJAW00
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="SYDIKJAW00Soap", [Namespace]:="http://tempuri.org/SYDIKJAW00/SYDIKJAW00")>  _
    Partial Public Class SYDIKJAW00
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private mSetOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://knapsv/JPGAP/SY/SYDIKJAW/SYDIKJAW00/SYDIKJAW00.asmx"
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
        Public Event mSetCompleted As mSetCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SYDIKJAW00/SYDIKJAW00/mSet", RequestNamespace:="http://tempuri.org/SYDIKJAW00/SYDIKJAW00", ResponseNamespace:="http://tempuri.org/SYDIKJAW00/SYDIKJAW00", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function mSet(ByVal pstrKANSCD As String, ByVal pstrDAIKOKANSCD As String, ByVal pstrMode As String) As String
            Dim results() As Object = Me.Invoke("mSet", New Object() {pstrKANSCD, pstrDAIKOKANSCD, pstrMode})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginmSet(ByVal pstrKANSCD As String, ByVal pstrDAIKOKANSCD As String, ByVal pstrMode As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("mSet", New Object() {pstrKANSCD, pstrDAIKOKANSCD, pstrMode}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndmSet(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub mSetAsync(ByVal pstrKANSCD As String, ByVal pstrDAIKOKANSCD As String, ByVal pstrMode As String)
            Me.mSetAsync(pstrKANSCD, pstrDAIKOKANSCD, pstrMode, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub mSetAsync(ByVal pstrKANSCD As String, ByVal pstrDAIKOKANSCD As String, ByVal pstrMode As String, ByVal userState As Object)
            If (Me.mSetOperationCompleted Is Nothing) Then
                Me.mSetOperationCompleted = AddressOf Me.OnmSetOperationCompleted
            End If
            Me.InvokeAsync("mSet", New Object() {pstrKANSCD, pstrDAIKOKANSCD, pstrMode}, Me.mSetOperationCompleted, userState)
        End Sub
        
        Private Sub OnmSetOperationCompleted(ByVal arg As Object)
            If (Not (Me.mSetCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent mSetCompleted(Me, New mSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub mSetCompletedEventHandler(ByVal sender As Object, ByVal e As mSetCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1590.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class mSetCompletedEventArgs
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

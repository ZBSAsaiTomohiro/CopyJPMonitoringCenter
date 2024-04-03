Option Explicit On 
Option Strict On

Namespace Common
    Public Class CCompressZip

        '******************************************************************************
        '*　概　要：ファイルの圧縮(zip) ICSharpCode.SharpZipLib.dll使用(要参照設定)
        '*　備　考：
        '******************************************************************************
        Public Sub fncMakeZipWithPass(ByVal sXlsFilePath As String, ByVal sZipFilePath As String, ByVal sPass As String)

            '圧縮するファイルの設定 
            'Dim filePaths(100) As String
            Dim crc As ICSharpCode.SharpZipLib.Checksums.Crc32

            Dim writer As System.IO.FileStream
            Dim zos As ICSharpCode.SharpZipLib.Zip.ZipOutputStream
            Dim f As String
            Dim fs As System.IO.FileStream
            Dim buffer() As Byte
            Dim ze As ICSharpCode.SharpZipLib.Zip.ZipEntry

            Dim file As String
            'filePaths(0) = sXlsFilePath

            If Len(sPass) <= 0 Then
                sPass = "jalp" 'パスワードのデフォルトはjalp
            End If

            crc = New ICSharpCode.SharpZipLib.Checksums.Crc32
            writer = New System.IO.FileStream( _
                            sZipFilePath, System.IO.FileMode.Create, _
                            System.IO.FileAccess.Write, _
                            System.IO.FileShare.Write)
            zos = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(writer)

            ' 圧縮レベルを設定する 
            zos.SetLevel(6)
            ' パスワードを設定する 
            zos.Password = sPass

            ' Zipにファイルを追加する 
            If True Then
                'For Each file As String In filePaths '(複数ファイルを１つのzipに圧縮することもできる。)
                file = sXlsFilePath

                ' ZIPに追加するときのファイル名を決定する 
                f = System.IO.Path.GetFileName(file)
                ze = New ICSharpCode.SharpZipLib.Zip.ZipEntry(f)
                ze.CompressionMethod = ICSharpCode.SharpZipLib.Zip.CompressionMethod.Stored 'この1行でWindows標準でのPASS解凍問題が解決！？

                ' ヘッダを設定する 
                ' ファイルを読み込む 
                fs = New System.IO.FileStream( _
                            file, _
                            System.IO.FileMode.Open, _
                            System.IO.FileAccess.Read, _
                            System.IO.FileShare.Read)
                ReDim buffer(CInt(fs.Length))

                fs.Read(buffer, 0, buffer.Length)
                fs.Close()
                ' CRCを設定する 
                crc.Reset()
                crc.Update(buffer)
                ze.Crc = crc.Value
                ' サイズを設定する 
                ze.Size = buffer.Length

                ' 時間を設定する 
                ze.DateTime = DateTime.Now

                ' 新しいエントリの追加を開始 
                zos.PutNextEntry(ze)
                ' 書き込む 
                zos.Write(buffer, 0, buffer.Length)

                'Next
            End If

            zos.Close()
            writer.Close()
        End Sub




    End Class

End Namespace

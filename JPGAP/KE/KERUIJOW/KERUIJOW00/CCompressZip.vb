Option Explicit On 
Option Strict On

Namespace Common
    Public Class CCompressZip

        '******************************************************************************
        '*�@�T�@�v�F�t�@�C���̈��k(zip) ICSharpCode.SharpZipLib.dll�g�p(�v�Q�Ɛݒ�)
        '*�@���@�l�F
        '******************************************************************************
        Public Sub fncMakeZipWithPass(ByVal sXlsFilePath As String, ByVal sZipFilePath As String, ByVal sPass As String)

            '���k����t�@�C���̐ݒ� 
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
                sPass = "jalp" '�p�X���[�h�̃f�t�H���g��jalp
            End If

            crc = New ICSharpCode.SharpZipLib.Checksums.Crc32
            writer = New System.IO.FileStream( _
                            sZipFilePath, System.IO.FileMode.Create, _
                            System.IO.FileAccess.Write, _
                            System.IO.FileShare.Write)
            zos = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(writer)

            ' ���k���x����ݒ肷�� 
            zos.SetLevel(6)
            ' �p�X���[�h��ݒ肷�� 
            zos.Password = sPass

            ' Zip�Ƀt�@�C����ǉ����� 
            If True Then
                'For Each file As String In filePaths '(�����t�@�C�����P��zip�Ɉ��k���邱�Ƃ��ł���B)
                file = sXlsFilePath

                ' ZIP�ɒǉ�����Ƃ��̃t�@�C���������肷�� 
                f = System.IO.Path.GetFileName(file)
                ze = New ICSharpCode.SharpZipLib.Zip.ZipEntry(f)
                ze.CompressionMethod = ICSharpCode.SharpZipLib.Zip.CompressionMethod.Stored '����1�s��Windows�W���ł�PASS�𓀖�肪�����I�H

                ' �w�b�_��ݒ肷�� 
                ' �t�@�C����ǂݍ��� 
                fs = New System.IO.FileStream( _
                            file, _
                            System.IO.FileMode.Open, _
                            System.IO.FileAccess.Read, _
                            System.IO.FileShare.Read)
                ReDim buffer(CInt(fs.Length))

                fs.Read(buffer, 0, buffer.Length)
                fs.Close()
                ' CRC��ݒ肷�� 
                crc.Reset()
                crc.Update(buffer)
                ze.Crc = crc.Value
                ' �T�C�Y��ݒ肷�� 
                ze.Size = buffer.Length

                ' ���Ԃ�ݒ肷�� 
                ze.DateTime = DateTime.Now

                ' �V�����G���g���̒ǉ����J�n 
                zos.PutNextEntry(ze)
                ' �������� 
                zos.Write(buffer, 0, buffer.Length)

                'Next
            End If

            zos.Close()
            writer.Close()
        End Sub




    End Class

End Namespace

# ADBK ODBC

## ADBKODBCプロジェクト

Visual Studioを起動し、ファイル>新規作成>プロジェクトをクリック

### テンプレートを選択

Windows フォームアプリケーション(.NET Framework)

Windows Form（WinForms）ユーザーインタフェースを含むアプリケーションを作成するためのプロジェクトです。

VB.NET

プロジェクト名およびソリューション名

- ADBKODBC

フレームワーク

- .NET Framework 4.8

### ファイル追加、参照設定

#### Form1.vbを削除

#### 既存の項目を追加

- frmADONET.resX
- frmADONET.vb
- setup.vb

#### プロジェクト>参照の追加

- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\NewtonsoftJson.dllを追加

#### プロジェクト設定変更

プロジェクト>ADBKADONETのプロパティ

アプリケーションパネル

スタートアップフォーム　

- frmADONET.vb

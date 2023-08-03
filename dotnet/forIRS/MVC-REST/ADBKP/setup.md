# ADBK MVCREST

## ADBKMVCRESTプロジェクト

Visual Studioを起動し、ファイル>新規作成>プロジェクトをクリック

### テンプレートを選択

Windows フォームアプリケーション(.NET Framework)

Windows Form（WinForms）ユーザーインタフェースを含むアプリケーションを作成するためのプロジェクトです。

C##

プロジェクト名およびソリューション名

- ADBKMVCREST

フレームワーク

- .NET Framework 4.8

### ファイル追加、参照設定

#### Form1.csを削除

#### 既存の項目を追加

- ADBKDataModel.cs
- ADBKDataSource.cs
- ClassDiagram1.cd
- Form1.Designers.cs
- Form1.cs
- Form1.resX
- Program.cs
- adbk.cs

#### プロジェクト>参照の追加

- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\InterSystems.Data.IRISClient.dllを追加
- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\NewtonsoftJson.dllを追加

#### プロジェクト設定変更

プロジェクト>ADBKMVCRESTのプロパティ

アプリケーションパネル

スタートアップフォーム　

- Form1.cs

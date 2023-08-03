# ADBK CacheListプロジェクト

## ADBKLISTプロジェクト

Visual Studioを起動し、ファイル>新規作成>プロジェクトをクリック

### テンプレートを選択

Windows フォームアプリケーション(.NET Framework)

Windows Form（WinForms）ユーザーインタフェースを含むアプリケーションを作成するためのプロジェクトです。

VB.NET

プロジェクト名およびソリューション名

- ADBKLIST

フレームワーク

- .NET Framework 4.8

### ファイル追加、参照設定

#### Form1.vbを削除

#### 既存の項目を追加

- ADBKMain.Designer.vb
- ADBKMain.resX
- ADBKMain.vb
- DataSet1.Designer.vb
- DataSet1.xsc
- DataSet1.xsd
- DataSet1.xss
- FindByName.Designer.vb
- FindByName.resX
- FindByName.vb
- IRISListHelper.vb
- setup.vb

#### プロジェクト>参照の追加

- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\InterSystems.Data.IRISClient.dllを追加
- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\NewtonsoftJson.dllを追加

#### プロジェクト設定変更

プロジェクト>ADBKLISTのプロパティ

アプリケーションパネル

スタートアップフォーム　

- ADBKMain

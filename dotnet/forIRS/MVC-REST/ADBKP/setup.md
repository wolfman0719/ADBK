# ADBK MVCREST

## ビルド環境

Visual Studio 2022

## ADBKMVCRESTプロジェクト

Visual Studio 2022を起動し、ファイル>新規作成>プロジェクトをクリック

### テンプレートを選択

Windows フォームアプリケーション(.NET Framework　C##)

Windows Form（WinForms）ユーザーインタフェースを含むアプリケーションを作成するためのプロジェクトです。

プロジェクト名およびソリューション名(任意の名前でOK)

- ADBKMVCREST


### ファイル追加、参照設定

#### Form1.csとProgram.csを削除

この作業を必ず最初に実行
（あとの作業がうまくいかない）

#### 既存の項目を追加

- ADBKDataModel.cs
- ADBKDataSource.cs
- ClassDiagram1.cd
- Form1.Designers.cs
- Form1.cs
- Form1.resX
- Program.cs

#### プロジェクト>参照の追加

- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\InterSystems.Data.IRISClient.dllを追加
- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\NewtonsoftJson.dllを追加

#### プロジェクト設定変更

プロジェクト>ADBKMVCRESTのプロパティ

アプリケーションパネル

スタートアップオブジェクト(Visual Studio 2022)

- ADBKP.Program

### 環境依存

デフォルトでは、Webサーバーとの接続は、2023.2以降のWindows環境でIISをWebサーバーとして設定した場合のWebアプリケーション設定が前提となっている。

2023.1以前のPrivate Webサーバー環境で実行する際には、ADBKDataModel.cs-52773でADBKDataModel.csで置き換えてビルドする。
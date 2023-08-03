# ADBK CacheDirectプロジェクト

## CacheDirect.dllの作成

Visual Studioを起動し、ファイル>新規作成>プロジェクトをクリック

### テンプレートを選択

クラス　ライブラリ（.Net Framework)

C# クラスライブラリー（.dll）を作成するためのプロジェクトです。

プロジェクト名およびソリューション名

- CacheDirect

フレームワーク 

- .Net Framework 4.8

### ファイル追加、参照設定

class1.csをプロジェクトから削除

プロジェクト>既存の項目の追加をクリック

CacheDirectWapper.csを追加

プロジェクト>参照の追加

IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\InterSystems.Data.IRISClient.dllを追加

### dllのビルド

ビルド>ソリューションのビルド

## ADBKCacheDirectプロジェクト

Visual Studioを起動し、ファイル>新規作成>プロジェクトをクリック

### テンプレートを選択

Windows フォームアプリケーション(.NET Framework)

Windows Form（WinForms）ユーザーインタフェースを含むアプリケーションを作成するためのプロジェクトです。

プロジェクト名およびソリューション名

- ADBKCacheDirect

フレームワーク

- .NET Framework 4.8

### ファイル追加、参照設定

#### Form1.vbを削除

#### 既存の項目を追加

- ADBKMain.Designer.vb
- ADBKMain.resX
- ADBKMain.vb
- FindByName.Designer.vb
- FindByName.resX
- FindByName.vb
- setup.vb

#### プロジェクト>参照の追加

- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\InterSystems.Data.IRISClient.dllを追加
- IRISインストールディレクトリ\dev\dotnet\bin\v4.6.2\NewtonsoftJson.dllを追加
- Cachedirect.dll(最初のステップでビルドしたdll)

#### プロジェクト設定変更

プロジェクト>ADBKCacheDirectのプロパティ

アプリケーションパネル

スタートアップフォーム　

- ADBKMain

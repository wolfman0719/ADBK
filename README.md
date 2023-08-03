# ADBK DEMO

ADBK(アドレス帳).Netデモアプリケーション for IRIS

IRISで用意された様々な.Net APIを使用したサンプル

## ディレクトリ構造

### ActiveX

VB6でCacheObject.dll を利用したサンプルをIRISの.Net Native APIで書き直したサンプル

#### forIRIS

.Net Native APIバージョン

#### Project1.Net

VB6のプロジェクトをVisual Studio 2008で変換したプロジェクト

#### VB6

VB6でCacheObject.dllを利用したサンプル

### ADO

VB6でADO.Netを使用したサンプルをIRISのADO.Netで書き直したサンプル

#### forIRIS

ADO.Net for IRISバージョン

#### Project1.NET

VB6のプロジェクトをVisual Studio 2008で変換したプロジェクト

#### VB6

VB6でADO.Netを使用したサンプル

### adodotnet

ADO.netを使用したVB.netサンプル

#### for Cache

Cache用プロジェクト(ODBC)

#### forIRISODBC

IRIS用プロジェクト(ODBC)

#### forIRISManagedProvider

IRIS用プロジェクト（IRIS ADO.Net）

### CacheDirect

VB6のCache Direct（VisM.OCX）を使用したサンプルを.Net Native APIを使用したCacheDirectEmulatorで書き換えたサンプル

#### forIRIS

IRIS用にCacheDirect Emulatorを使用して書き換えたバージョン

#### Project1.NET

VB6のプロジェクトをVisual Studio 2008でVB.NETに変換したプロジェクト

#### VB6

VisM.OCXを使用したサンプル

### CacheList

CacheListを使用したサンプルをIRIS用に書き換えたサンプル

#### forIRIS

ADO.Netを使用してIRIS用に書き換えたサンプル

#### Project.NET

VB6のプロジェクトをVisual Studio 2008でVB.NETに変換したプロジェクト

#### Vb6

CacheList.OCXを使用したサンプル

### dotnet

C#のサンプル

MVCモデルを使用したサンプル

#### forCache

Cache用サンプル

#### forIRIS

##### MVC-adonet

ADO.NETを使用したサンプル

##### MVC-direct

.Net Native APIを使用したサンプル

##### MVC-objbind

.Net Native APIを使用したサンプル

##### MVC-REST

REST/JSONを使用したサンプル

## 事前準備

### connectioninfo.json

各サンプルの実行イメージ（通常はbinの下）の1つ上の階層にconnectioninfo.jsonを置く

ファイルの形式は、

 `{"username":"_system","password":"SYS","port":51773,"irisnamespace":"USER","hostname":"localhost"} `

IRISの実行環境に合わせてファイルの内容を変更

### IRISルーチン、グローバル、クラスのロード

サンプルを動かすネームスペース（デフォルトUser）に必要なルーチン、グローバル、クラスをロードする

build/adbk

- ADBK.mac
- adbkglb.xml
- VISMUTIL.mac

build/adbk/ADBK

- Broker.cls
- JSON.cls

build/adbk/User

- ADBK.cls

### CacheDirect Emulator

CacheDirect Emulatorを使用するサンプルの事前設定は、以下参照

[CacheDirect EmulatorのGithub](https://github.com/wolfman0719/CacheDirectEmulator.git)


### REST設定

管理ポータル>システム管理>セキュリティ>アプリケーション>ウェブ・アプリケーション

新しいウェブ・アプリケーションを作成

- 名前:  /adbk
- ネームスペース: User（デフォルト）
- 有効　REST
- ディスパッチ・クラス: ADBK.Broker

保存ボタンを押す

### Visula Studioプロジェクト作成方法

CacheDirectの所のsetup.mdを参考にして設定
（参照設定等がプリジェクト毎に異なる）

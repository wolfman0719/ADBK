# ADBK DEMO

ADBK(アドレス帳).Netデモアプリケーション for IRIS

IRISで用意された様々な.Net APIを使用したサンプル

## ディレクトリ構造

### 1. ActiveX

VB6でCacheObject.dll を利用したサンプルをIRISの.Net Native APIで書き直したサンプル

#### 1.1 forIRIS

.Net Native APIバージョン

#### 1.2 Project1.Net

VB6のプロジェクトをVisual Studio 2008で変換したプロジェクト

#### 1.3 VB6

VB6でCacheObject.dllを利用したサンプル

### 2. ADO

VB6でADO.Netを使用したサンプルをIRISのADO.Netで書き直したサンプル

#### 2.1 forIRIS

ADO.Net for IRISバージョン

#### 2.2 Project1.NET

VB6のプロジェクトをVisual Studio 2008で変換したプロジェクト

#### 2.3 VB6

VB6でADO.Netを使用したサンプル

### 3. adodotnet

ADO.netを使用したVB.netサンプル

#### 3.1 for Cache

Cache用プロジェクト(ODBC)

#### 3.2 for IRISODBC

IRIS用プロジェクト(ODBC)

#### 3.3 for IRIS ManagedProvider

IRIS用プロジェクト（IRIS ADO.Net）

### 4. CacheDirect

VB6のCache Direct（VisM.OCX）を使用したサンプルを.Net Native APIを使用したCacheDirectEmulatorで書き換えたサンプル

#### 4.1 forIRIS

IRIS用にCacheDirect Emulatorを使用して書き換えたバージョン

#### 4.2 Project1.NET

VB6のプロジェクトをVisual Studio 2008でVB.NETに変換したプロジェクト

#### 4.3 VB6

VisM.OCXを使用したサンプル

### 5. CacheList

CacheListを使用したサンプルをIRIS用に書き換えたサンプル

#### 5.1 forIRIS

ADO.Netを使用してIRIS用に書き換えたサンプル

#### 5.2 Project.NET

VB6のプロジェクトをVisual Studio 2008でVB.NETに変換したプロジェクト

#### 5.3 Vb6

CacheList.OCXを使用したサンプル

### 6. dotnet

C#のサンプル

MVCモデルを使用したサンプル

#### 6.1 forCache

Cache用サンプル

#### 6.2 forIRIS

##### 6.2.1 MVC-adonet

ADO.NETを使用したサンプル

##### 6.2.2 MVC-direct

.Net Native APIを使用したサンプル

##### 6.2.3 MVC-objbind

.Net Native APIを使用したサンプル

##### 6.2.4 MVC-REST

REST/JSONを使用したサンプル

### 7. react

reactによるWebアプリケーションサンプル
詳細は、react-setup.mdを参照

## 事前準備

### connectioninfo.json

各サンプルの実行イメージ（通常はbinの下）の1つ上の階層にconnectioninfo.jsonを置く

ファイルの形式は、

 `{"username":"_system","password":"SYS","port":1972,"irisnamespace":"USER","hostname":"localhost"} `

IRISの実行環境に合わせてファイルの内容を変更

### IRISルーチン、グローバル、クラスのロード

サンプルを動かすネームスペース（デフォルトUser）に必要なルーチン、グローバル、クラスをロードする

src

- ADBK.mac
- adbkglb.xml
- VISMUTIL.mac

src/ADBK

- Broker.cls
- JSON.cls

src/User

- ADBK.cls

### CacheDirect Emulator

CacheDirect Emulatorを使用するサンプルの事前設定は、以下参照

[CacheDirect EmulatorのGithub](https://github.com/wolfman0719/CacheDirectEmulator.git)

### Visula Studioプロジェクト作成方法

CacheDirectの所のsetup.mdを参考にして設定
（参照設定等がプリジェクト毎に異なる）

### REST設定

管理ポータル>システム管理>セキュリティ>アプリケーション>ウェブ・アプリケーション

新しいウェブ・アプリケーションを作成

- 名前:  /api/adbk
- ネームスペース: User（デフォルト）
- 有効　REST
- ディスパッチ・クラス: ADBK.Broker

保存ボタンを押す

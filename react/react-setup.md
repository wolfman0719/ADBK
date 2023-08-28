# reactアプリケーション（PC版）設定

## react app テンプレート作成

```% npx create-react-app adbk --template typescript```

## bootstrapインストール

```% cd adbk```

```% npm install react-bootstrap bootstrap```

## react-router-domインストール

```% npm install react-router-dom```

## axios インストール

```% npm install axios```

## ファイルコピー

以下のファイルをここからダウンロードし、上で作成したテンプレートディレクトリにコピーする

- public

  index.html

- src

  index.tsx

  App.tsx

  serverconfig.json

 - components

   Adbk.tsx
   
## serverconfig.jsonの調整

 IRISサーバーのIPアドレス、ポート番号を反映
 (デフォルト　IPアドレス = localhost IPポート番号: 8080)

 docker環境では、ポート番号を52775に変更する

## reactアプリケーションの起動

- npm start

    Starts the development server.

- npm run build

    Bundles the app into static files for production.

- npm test

    Starts the test runner.

- npm run eject

    Removes this tool and copies build dependencies, configuration files
    and scripts into the app directory. If you do this, you can’t go back!

## http.confの修正

CORSの設定が必要

macOSの場合

```
/opt/homebrew/etc/httpd
```

```
<Directory />
    Options MultiViews FollowSymLinks
    AllowOverride None
    Require all granted
    <FilesMatch "\.(log|ini|pid|exe|so)$">
        Require all denied
    </FilesMatch>
</Directory>
```


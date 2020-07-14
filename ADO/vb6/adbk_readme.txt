
Cache' ADO サンプルアプリケーション

		　　　　InterSystems Japan
                        	2004/5/02

1.　はじめに

このアプリケーションは、ODBCによるCache'　ADOアプリケーション
の基本的な構築方法を示すサンプルアプリケーションです。

データベースからの参照、データベース更新、削除、変更等の処理方法、
エラー処理方法などを学習できます。

2.　インストレーション方法

2.1. adbk.zipをWinZip等のツールで適当なディレクトリに解凍して下さい。

2.2 ODBC DSN

コントロールパネル->管理ツール->データソース（ODBC）

InterSystems Cache ODBC Data Source Setup

Unicode SQLTypes をチェックしない。

3. 制限事項

Unicode SQLTypesをチェックすると、ADOのUpdateメソッドは動作しない。
V5.0.xでの制限事項である。


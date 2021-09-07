using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace cs_form_framework_mysql_datagridview_update
{
    public partial class Form1 : Form
    {
        // *****************************
        // SQL文字列格納用
        // *****************************
        private string query = "select * from 社員マスタ";

        // *****************************
        // 接続文字列作成用
        // *****************************
        private OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();

        public Form1()
        {
            InitializeComponent();

            SetBuilderData();
        }

        // *****************************
        // 接続文字列の準備
        // *****************************
        private void SetBuilderData()
        {
            // ドライバ文字列をセット ( 波型括弧{} は必要ありません ) 
            builder.Driver = "MySQL ODBC 8.0 Unicode Driver";

            // 接続用のパラメータを追加
            builder.Add("server", "localhost");
            builder.Add("database", "lightbox");
            builder.Add("uid", "root");
            builder.Add("pwd", "");
        }

        // *****************************
        // SELECT 文よりデータ表示
        // *****************************
        private void LoadMySQL()
        {

            // 接続と実行用のクラス
            using (OdbcConnection connection = new OdbcConnection())
            using (OdbcCommand command = new OdbcCommand())
            {
                // 接続文字列
                connection.ConnectionString = builder.ConnectionString;

                try
                {
                    // 接続文字列を使用して接続
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                // コマンドオブジェクトに接続をセット
                command.Connection = connection;
                // コマンドを通常 SQL用に変更
                command.CommandType = CommandType.Text;

                // *****************************
                // 実行 SQL
                // *****************************
                command.CommandText = query;

                try
                {
                    // レコードセット取得
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        // データを格納するテーブルクラス
                        DataTable dataTable = new DataTable();

                        // DataReader よりデータを格納
                        dataTable.Load(reader);

                        // 画面の一覧表示用コントロールにセット
                        dataMySQL.DataSource = dataTable;

                        // リーダを使い終わったので閉じる
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    // 接続解除
                    connection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }

                // 接続解除
                connection.Close();
            }

            // カラム幅の自動調整
            dataMySQL.AutoResizeColumns();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadMySQL();
        }

        private void targetUpdate_Click(object sender, EventArgs e)
        {
            using (OdbcConnection connection = new OdbcConnection())
            {
                // 接続文字列
                connection.ConnectionString = builder.ConnectionString;

                // 更新を管理するクラス
                // ※ 更新するには、テーブルに主キーが必要です
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                // 参照用のマップを追加
                adapter.TableMappings.Add("Table", "社員マスタ");
                // 接続とコマンド( コマンドは更新用のレコードを取得した SQL ) 
                adapter.SelectCommand = new OdbcCommand(query, connection);

                // 更新用のオブジェクトを準備
                OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(adapter);
                // 更新用のコマンドを取得
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();

                // 更新用 SQL のベース文字列
                Console.WriteLine(adapter.UpdateCommand.CommandText);

                // *****************************
                // 更新
                // *****************************
                try
                {
                    // DataGridView の内容を使用して更新
                    // ※ 他で更新されてしまった行は更新エラーとなります
                    // ※ 内部で管理された更新予定行を対象として更新します
                    adapter.Update((DataTable)dataMySQL.DataSource);

                    MessageBox.Show("更新を終了しました");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

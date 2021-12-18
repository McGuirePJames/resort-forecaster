$connectionString =  'Data Source="localhost, 1433";User ID=sa;Password=Abcd1234!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;'
$connectionStringInitialCatalog = 'Data Source="localhost, 1433";Initial Catalog=ResortForecaster;User ID=sa;Password=Abcd1234!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;'
$databaseName = "ResortForecaster"

function runQuery {
    param (
        $Query,
        $ConnectionStringLocal
    )

    $sqlConn = New-Object System.Data.SqlClient.SqlConnection

    if ($ConnectionStringLocal) {
        $sqlConn.ConnectionString = $ConnectionStringLocal
    } else {
        $sqlConn.ConnectionString = $connectionString
    }

    $sqlConn.Open()
    $sqlcmd = $sqlConn.CreateCommand()
    $sqlcmd = New-Object System.Data.SqlClient.SqlCommand
    $sqlcmd.Connection = $sqlConn
    $sqlcmd.CommandText = $Query

    $sqlcmd.ExecuteNonQuery()
    $sqlConn.Close()

}

function createDatabase {
    runQuery 'CREATE DATABASE ResortForecaster'
}

function init {
	createDatabase

	$sqlFiles = Get-ChildItem -Path Migrations -recurse | select FullName

	foreach ($sqlFile in $sqlFiles) {
		Write-Host $sqlFile.FullName
		$content = Get-Content -Path $sqlFile.FullName
		
		runQuery $content $connectionStringInitialCatalog
	}
}

init

Read-Host -Prompt "Press Enter to exit"
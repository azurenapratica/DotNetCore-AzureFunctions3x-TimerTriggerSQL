using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Dapper;

namespace TimerTriggerSQL
{
    public static class Processamento
    {
        [FunctionName("Processamento")]
        public static void Run([TimerTrigger("*/20 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            string mensagem = "|" + Environment.GetEnvironmentVariable("Local") + "|" +
                $"C# Timer trigger function executada em: {DateTime.Now}";

            using (var conexao = new SqlConnection(
                Environment.GetEnvironmentVariable("BaseProcessamento")))
            {
                conexao.Execute("INSERT INTO dbo.Log (Horario, Mensagem) " + 
                                "VALUES (GETDATE(), @Mensagem)",
                                new { Mensagem = mensagem });
            }

            log.LogInformation(mensagem);
        }
    }
}
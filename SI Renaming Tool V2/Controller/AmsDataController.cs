using Oracle.ManagedDataAccess.Client;
using SI_Renaming_Tool_V2.Controller;
using SI_Renaming_Tool_V2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

public class AmsDataController
{
    public List<AmsDataModel> GetData(int minFs, int maxFs)
    {
        var result = new List<AmsDataModel>();

        string connectionString =
            DBConfig.GetConnectionString();
        //Debug.WriteLine($"Connection String: {connectionString}");

        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();

            Debug.WriteLine("✅ Oracle connection opened successfully.");

            var cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = @"
                SELECT 
                AWI.INVOICE_CODE, AWI.INVOICE_NO, AWI.BILLING_PERIOD, AWI.STL_RUN, AWI.REMARKS, AWI.ID_NUMBER
                FROM 
                AM_WESM_INVOICE AWI 
                WHERE 
                AWI.INVOICE_CODE >= :minFs AND AWI.INVOICE_CODE <= :maxFs
                AND AWI.CHARGE_ID = 'AMS MFSTLS'";

            cmd.Parameters.Add(new OracleParameter("minFs", minFs));
            cmd.Parameters.Add(new OracleParameter("maxFs", maxFs));    

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int invoiceCode = reader.GetInt32(0);
                string invoiceNo = reader.GetString(1);
                int billingPeriod = reader.GetInt32(2);
                string stlRun = reader.GetString(3);
                string remarks = reader.GetString(4);
                string shortName = reader.GetString(5);
                //Debug.WriteLine($"Invoice Code  : {invoiceCode}");
                //Debug.WriteLine($"Invoice No    : {invoiceNo}");
                //Debug.WriteLine($"Billing Period: {billingPeriod}");
                //Debug.WriteLine($"STL Run       : {stlRun}");
                //Debug.WriteLine($"Remarks       : {remarks}");
                //Debug.WriteLine("-----------------------------------");

                var item = new AmsDataModel
                {
                    INVOICE_CODE = invoiceCode,
                    INVOICE_NO = invoiceNo,
                    BILLING_PERIOD = billingPeriod,
                    STL_RUN = stlRun,
                    REMARKS = remarks,
                    SHORT_NAME = shortName
                };

                result.Add(item);
            }

            reader.Close();
            con.Close();
            Debug.WriteLine("✅ Oracle connection closed successfully.");
        }
        catch (OracleException oex)
        {
            Debug.WriteLine("❌ OracleException occurred");
            Debug.WriteLine($"Error Code: {oex.Number}");
            Debug.WriteLine($"Message   : {oex.Message}");
            MessageBox.Show(oex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("❌ General Exception occurred");
            Debug.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        return result;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace MVCHackathon.utilities
{
    public class Common
    {
        private static Common _instance;

        public static Common Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Common();
                return _instance;
            }
        }

        public Common()
        {

        }
        public void ConvertRsObj(ref object oObject, DbDataReader reader)
        {
            Type oClassType;
            try
            {
                oClassType = oObject.GetType();

                reader.Read();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string sTableColumnName = reader.GetName(i);

                    Type oFieldType = reader.GetFieldType(i);

                    Type oPropertyType = null;
                    PropertyInfo oPropertyInfo = oClassType.GetProperty(sTableColumnName);
                    if (oPropertyInfo != null)
                        oPropertyType = oClassType.GetProperty(sTableColumnName).PropertyType;
                    else
                        continue;

                    object oFieldValue = reader[sTableColumnName];
                    string sFieldValue = null;
                    if (!DBNull.Value.Equals(oFieldValue))
                    {
                        sFieldValue = Convert.ToString(reader[sTableColumnName]);
                    }
                    object o;

                    if (oPropertyType.Name != oFieldType.Name)
                        o = fieldTypeInfo(oPropertyType, sFieldValue);
                    else
                        o = fieldTypeInfo(oFieldType, sFieldValue);

                    try
                    {
                        if (o != null && oPropertyInfo.CanWrite)
                            oPropertyInfo.SetValue(oObject, o, null);
                    }
                    catch (Exception exception)
                    {
                        string s = exception.Message;
                    }
                }
            }
            catch (Exception e)
            {
                string message = "Unable to retrieve data.";
                string debugInformation = string.Format("Exception occured in rsToObject");
                throw new DataException(message, e);
            }
        }

        public void ConvertRsObj(ref object oObject, DbDataReader oDDReader, object oClassName)
        {
            Type oCllctnType = null;
            object oClassObject = null;
            Type oClassType = null;

            try
            {
                //Get type of the collection object
                oCllctnType = oObject.GetType();

                if (oClassName != null)
                {
                    oClassType = oClassName.GetType();
                }

                if (oDDReader.HasRows)
                {
                    //Reading record one by one
                    while (oDDReader.Read())
                    {
                        //create instance of the class specified.
                        oClassObject = (object)Activator.CreateInstance(oClassType);

                        //Getting details of each field in a particular record.
                        for (int i = 0; i < oDDReader.FieldCount; i++)
                        {
                            // Returns the name of Field
                            string Name = oDDReader.GetName(i);

                            //Returns the type of each Field
                            Type oFieldType = oDDReader.GetFieldType(i);

                            //Returns the value of Field
                            string sValue = Convert.ToString(oDDReader[Name]);
                            if (Name == "InsertTimeStamp")
                            {
                                sValue = Convert.ToString(Convert.ToDateTime(oDDReader[Name]));
                            }
                            //Call to the function which returns object of Actual Data Type and value of the Field Passed 
                            PropertyInfo objectPropertyInfo = oClassType.GetProperty(Name);
                            if (objectPropertyInfo == null)
                            {
                                // Property of "Name" does not exist on the class ... skip and 
                                // go to next field --- Added by SV 16/07/12
                                continue;
                            }
                            Type oPropertyType = oClassType.GetProperty(Name).PropertyType;

                            object o;
                            if (oPropertyType.FullName != oFieldType.FullName)
                                o = fieldTypeInfo(oPropertyType, sValue);
                            else
                                o = fieldTypeInfo(oFieldType, sValue);

                            //Set the value to object
                            if (!objectPropertyInfo.CanWrite)
                                continue;

                            objectPropertyInfo.SetValue(oClassObject, o, null);
                        }
                        object[] oArrayClassObject = new object[1];
                        oArrayClassObject[0] = oClassObject;

                        //Invoke Add method of the collection class.
                        oCllctnType.GetMethod("Add").Invoke(oObject, oArrayClassObject);
                    }
                }

            }
            catch (Exception e)
            {
                string message = "Unable to retrieve data.";
                string debugInformation = string.Format("Exception occured in rsToCollection");
                throw new DataException(message, e);
            }
        }
        public object fieldTypeInfo(Type sFieldType, string sFieldValue)
        {
            object type = null;
            switch (sFieldType.Name)
            {
                case "String":
                    {
                        string lFieldValue = sFieldValue;
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                        break;
                    }
                case "Int16":
                    {
                        short lFieldValue = 0;
                        if (sFieldValue != string.Empty)
                            lFieldValue = Convert.ToInt16(sFieldValue);
                        //sType = short ;
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                        break;
                    }
                case "Int32":
                    {
                        int lFieldValue = 0;
                        if (sFieldValue != string.Empty)
                            lFieldValue = Convert.ToInt32(sFieldValue);
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                        break;
                    }
                case "Int64":
                    {
                        long lFieldValue = 0L;
                        if (sFieldValue != string.Empty)
                            lFieldValue = Convert.ToInt64(sFieldValue);
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                        break;
                    }
                case "Double":
                    {
                        double lFieldValue = 0.0;
                        if (sFieldValue != string.Empty)
                            lFieldValue = Convert.ToDouble(sFieldValue);
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                        break;
                    }
                case "Single":
                    {
                        float lFieldValue = 0.0F;
                        if (sFieldValue != string.Empty)
                            lFieldValue = Convert.ToSingle(sFieldValue);
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                        break;
                    }
                case "Decimal":
                    {
                        decimal lFieldValue = 0.0M;
                        if (sFieldValue != string.Empty)
                            lFieldValue = Convert.ToDecimal(sFieldValue);
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                        break;
                    }
                case "DateTime":
                    {
                        DateTime lFieldValue;

                        if (!string.IsNullOrEmpty(sFieldValue))
                        {
                            lFieldValue = Convert.ToDateTime(sFieldValue);
                            string sDate = String.Format("{0:s}", lFieldValue);
                            //type  = new object();
                            type = Convert.ChangeType(sDate, sFieldType);
                        }
                        break;
                    }
                case "Boolean":
                    {
                        bool lFieldValue = false;
                        if (!string.IsNullOrEmpty(sFieldValue))
                            lFieldValue = Convert.ToBoolean(Convert.ToInt32(sFieldValue));
                        type = Convert.ChangeType(lFieldValue, sFieldType);
                    }
                    break;
                case "Nullable`1":
                    {
                        if (sFieldValue != null)
                        {
                            Type nullableType = Nullable.GetUnderlyingType(sFieldType);
                            type = fieldTypeInfo(nullableType, sFieldValue);
                        }
                        else
                            type = null;
                    }
                    break;
                default:
                    {
                        if (sFieldType.BaseType.Name == "Enum")
                        {
                            // This logic handles conversion of an integer value in the 
                            // user defined Enum Type
                            type = System.Activator.CreateInstance(sFieldType);

                            int lFieldValue = 0;
                            if (sFieldValue != string.Empty)
                                lFieldValue = Convert.ToInt32(sFieldValue);

                            type = lFieldValue;
                        }
                        else
                            type = null;

                        break;
                    }
            }
            return type;
        }

        public DbDataReader CloseReader(DbDataReader reader)
        {
            if (reader != null)
            {
                if (!reader.IsClosed)
                    reader.Close();
                reader.Dispose();
            }
            reader = null;
            return reader;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLBuilderDemo
{
    public static class LoadTestData
    {
        static readonly int DATA_LENGTH = 30;

        public static TableData[] GetTestData()
        {
            TableData[] tables = new TableData[DATA_LENGTH];

            Random ran = new Random();

            for (int i = 0; i < tables.Length; i++)
            {
                tables[i] = new TableData("Table_" + i.ToString("00"), "��" + i.ToString("00"));

                for (int j = 0; j < ran.Next(DATA_LENGTH) + 1; j++)
                {
                    tables[i].Fields.Add(new FieldData("Field_" + j.ToString("00"), "�ֶ�" + j.ToString("00")));
                }
            }

            return tables;
        }
    }

    public class TableData
    {

        private Guid _id;

        /// <summary>
        /// ��ȡ������Table��Ψһ��ʾ��
        /// </summary>
        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _valName;

        /// <summary>
        /// ��ȡ������ʵ�ʵ��ֶ���
        /// </summary>
        public string ValName
        {
            get { return _valName; }
            set { _valName = value; }
        }

        private string _displayName;

        /// <summary>
        /// ��ȡ��������ʾ���ֶ���
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        private FiledCollection _fileds;

        /// <summary>
        /// ��ȡ�������ֶ�
        /// </summary>
        public FiledCollection Fields
        {
            get { return _fileds; }
            set { _fileds = value; }
        }

        public TableData()
        {
            _fileds = new FiledCollection();
            _id = Guid.NewGuid();
        }

        public TableData(string valName)
            : this()
        {
            this._displayName = valName;
            this._valName = valName;
        }

        public TableData(string valName, string displayName)
            : this()
        {
            this._displayName = displayName;
            this._valName = valName;
        }

        public override string ToString()
        {
            return this._displayName + "\t(" + this._valName + ")";
        }
    }

    public class FiledCollection : List<FieldData>
    {

    }

    public class FieldData
    {
        private Guid _id;

        /// <summary>
        /// ��ȡ�������ֶε�Ψһ��ʾ��
        /// </summary>
        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _valName;

        /// <summary>
        /// ��ȡ������ʵ�ʵ��ֶ���
        /// </summary>
        public string ValName
        {
            get { return _valName; }
            set { _valName = value; }
        }

        private string _displayName;

        /// <summary>
        /// ��ȡ��������ʾ���ֶ���
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public FieldData()
        {
            _id = Guid.NewGuid();
        }

        public FieldData(string valName)
            : this()
        {
            this._displayName = valName;
            this._valName = valName;
        }

        public FieldData(string valName, string displayName)
            : this()
        {
            this._displayName = displayName;
            this._valName = valName;
        }

        public override string ToString()
        {
            return this._displayName + "\t(" + this._valName + ")";
        }

    }
}

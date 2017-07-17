using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialActionsProcess
{
    public enum Operation : byte { Unknown, Buy, Sell }

    public class MaterialActionArgs:EventArgs 
    {
        //private Operation _operation = Operation.Unknown;
        public Operation MadeOperation
        {
            get;
        }
        public int Id
        { get; }
        public string MaterialName
        { get; }

        public string MateriaType
        { get; }

        public int Count
        { get; }
        public MaterialActionArgs(int id, string materialName,string materiatype,  Operation operation,int count)
        {
            Id = id;
            MaterialName = materialName;
            MateriaType = materiatype;
            MadeOperation = operation;
            Count = count;
        }

    }

    public class MateriaActionsProcessor
    {
        public event EventHandler<MaterialActionArgs> MaterialOperationEvent;
        //public delegate void MaterialOperationDelegate(MaterialActionArgs e);
        //public  MaterialOperationDelegate MaterialOperationEvent1;
        protected void OnMaterialMadeOperation(MaterialActionArgs e)
        {
            if (MaterialOperationEvent != null)
            {
                MaterialOperationEvent(this, e);
            }
        }

        public void GenerateMaterialOperationEvent(int id, string materialName, string materialtype, Operation operation, int count)
        {
            OnMaterialMadeOperation(new MaterialActionArgs(id, materialName, materialtype, operation,count));
        }
    }
}

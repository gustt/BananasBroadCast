using System;

namespace DBLayers.BLL.Interfaces
{
    interface IDataRecordDBLayers
    {
        int Insert();
        int Update();
        int Delete();
        bool IsNew();
    }
}

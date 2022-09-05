/*
 * 
 */
using Vo;

namespace ControlEx {
    public partial class VehicleDispatchControl : UserControl {
        public VehicleDispatchControl() {
            InitializeComponent();
        }

        public void CreateSetControl(VehicleDispatchControlVo vehicleDispatchControlVo) {
            /*
             * SetControlを作成する仕様は？
             * 
             * 
             * GarageFlag値によってBorderColorが変わる(三郷車庫からの配車を視覚的に表示する)
             * ProductionNumberOfPeople値によってTablLayoutPanelの枠数が決まる(本番人数を明示する)
             */
            var setControl = new SetControl();
            setControl.SetFlag = vehicleDispatchControlVo.SetFlag;
            setControl.StopCarFlag = vehicleDispatchControlVo.StopCarFlag;
            setControl.GarageFlag = vehicleDispatchControlVo.GarageFlag;
            setControl.ProductionNumberOfPeople = vehicleDispatchControlVo.ProductionNumberOfPeople;
            /*
             * SetLedgerVoがNullの場合CreateLabelを呼ばない
             */
            if (vehicleDispatchControlVo.SetLedgerVo != null)
                setControl.CreateLabel(vehicleDispatchControlVo.SetLedgerVo);
            /*
             * CarLedgerVoがNullの場合CreateLabelを呼ばない
             */
            if (vehicleDispatchControlVo.CarLedgerVo != null)
                setControl.CreateLabel(vehicleDispatchControlVo.CarLedgerVo);
            /*
             * ArrayStaffLedgerVo.Count()は最大4だよ(最大で運転手1名と作業員3名)
             */
            for (int i = 0; i < vehicleDispatchControlVo.ArrayStaffLedgerVo.Length; i++) {
                /*
                 * ArrayStaffLedgerVo[i]がNullの場合CreateLabelを呼ばない
                 */
                if (vehicleDispatchControlVo.ArrayStaffLedgerVo[i] != null)
                    setControl.CreateLabel(i, vehicleDispatchControlVo.ArrayStaffLedgerVo[i]);
            }

            TableLayoutPanelEx1.Controls.Add(setControl, vehicleDispatchControlVo.Column, vehicleDispatchControlVo.Row);
        }
    }
}

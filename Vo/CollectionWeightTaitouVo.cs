/*
 * 2023-07-25
 */
namespace Vo {
    public class CollectionWeightTaitouVo {
        private DateTime _operation_date;
        private int _weight1;
        private int _weight2;
        private int _weight3;
        private int _weight4;
        private int _weight5;
        private int _weight6;
        private string _insert_pc_name;
        private DateTime _insert_ymd_hms;
        private string _update_pc_name;
        private DateTime _update_ymd_hms;
        private string _delete_pc_name;
        private DateTime _delete_ymd_hms;
        private bool _delete_flag;

        private readonly DateTime _defaultDateTime = new DateTime(1900,01,01);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public CollectionWeightTaitouVo() {

        }

    }
}

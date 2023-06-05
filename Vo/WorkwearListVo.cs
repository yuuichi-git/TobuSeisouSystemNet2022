/*
 * 2023-06-03
 * 画面（WorkwearList）への受け渡し用のVo
 */
namespace Vo {
    public class WorkwearListVo {
        private int _staff_code;
        private int _workwear_up;
        private int _workwear_down;
        private int _helmet;
        private int _hat;
        private int _safety_shose;
        private int _long_shose;
        private int _glove;

        /// <summary>
        /// 従事者コード
        /// </summary>
        public int Staff_code {
            get => _staff_code;
            set => _staff_code = value;
        }
        /// <summary>
        /// 作業着上
        /// </summary>
        public int Workwear_up {
            get => _workwear_up;
            set => _workwear_up = value;
        }
        /// <summary>
        /// 作業着下
        /// </summary>
        public int Workwear_down {
            get => _workwear_down;
            set => _workwear_down = value;
        }
        /// <summary>
        /// ヘルメット
        /// </summary>
        public int Helmet {
            get => _helmet;
            set => _helmet = value;
        }
        /// <summary>
        /// 帽子
        /// </summary>
        public int Hat {
            get => _hat;
            set => _hat = value;
        }
        /// <summary>
        /// 安全靴
        /// </summary>
        public int Safety_shose {
            get => _safety_shose;
            set => _safety_shose = value;
        }
        /// <summary>
        /// 長靴
        /// </summary>
        public int Long_shose {
            get => _long_shose;
            set => _long_shose = value;
        }
        /// <summary>
        /// 手袋
        /// </summary>
        public int Glove {
            get => _glove;
            set => _glove = value;
        }
    }
}

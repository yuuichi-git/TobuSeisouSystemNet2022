namespace H_Common {
    public class Desktop {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public Rectangle GetWorkingArea(Control control) {
            return Screen.GetWorkingArea(control);
        }
    }
}

namespace Mecalux.ITSW.EasyB.Model
{
    public enum CheckDigit
    {
        None = 0,
        Modulus43 = 1,
        Modulus10 = 2,

        /// <summary>
        /// Ignores the las position of the data because it's assumed that it's a digit control
        /// </summary>
        WildCar = 3,
    }
}

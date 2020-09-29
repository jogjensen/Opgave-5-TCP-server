using System;
using System.Collections.Generic;
using System.Text;

namespace BikeServer
{
    public class Bike
    {
        #region Instance fields
        private static int _idAuto = 1;
        private int _id;
        private string _color;
        private int _price;
        private int _gear;
        private bool _mtb;
        #endregion


        #region Constructors
        public Bike(string color, int price, int gear, bool mtb)
        {
            _id = _idAuto++;
            _color = color;
            _price = price;
            _gear = gear;
            _mtb = mtb;
        }

        public Bike()
        {
        }
        #endregion


        #region Properties
        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public int Gear
        {
            get => _gear;
            set => _gear = value;
        }

        public bool Mtb
        {
            get => _mtb;
            set => _mtb = value;
        }
        #endregion


        #region Methods

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Color)}: {Color}, {nameof(Price)}: {Price}, {nameof(Gear)}: {Gear}, {nameof(Mtb)}: {Mtb}";
        }

        #endregion



    }
}

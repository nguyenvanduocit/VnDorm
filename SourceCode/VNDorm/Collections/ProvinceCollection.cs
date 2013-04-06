using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace VNDorm.Collections
{
    public class ProvinceCollection : ObservableCollection<string>
    {
        private static object _threadLock = new Object();
        private static ProvinceCollection current;
        public static ProvinceCollection Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                    {
                        current = new ProvinceCollection();
                        current.Add( "Cần Thơ" );
                        current.Add( "Đà Nẵng" );
                        current.Add( "Hải Phòng" );
                        current.Add( "Hà Nội" );
                        current.Add( "Thành phố Hồ Chí Minh" );
                        current.Add( "An Giang" );
                        current.Add( "Bà Rịa - Vũng Tàu" );
                        current.Add( "Bạc Liêu" );
                        current.Add( "Bắc Giang" );
                        current.Add( "Bắc Kạn" );
                        current.Add( "Bắc Ninh" );
                        current.Add( "Bến Tre" );
                        current.Add( "Bình Dương" );
                        current.Add( "Bình Định" );
                        current.Add( "Bình Phước" );
                        current.Add( "Bình Thuận" );
                        current.Add( "Cà Mau" );
                        current.Add( "Cao Bằng" );
                        current.Add( "Đắk Lắk" );
                        current.Add( "Đắk Nông" );
                        current.Add( "Điện Biên" );
                        current.Add( "Đồng Nai" );
                        current.Add( "Đồng Tháp" );
                        current.Add( "Gia Lai" );
                        current.Add( "Hà Giang" );
                        current.Add( "Hà Nam" );
                        current.Add( "Hà Tĩnh" );
                        current.Add( "Hải Dương" );
                        current.Add( "Hậu Giang" );
                        current.Add( "Hòa Bình" );
                        current.Add( "Hưng Yên" );
                        current.Add( "Khánh Hòa" );
                        current.Add( "Kiên Giang" );
                        current.Add( "Kon Tum" );
                        current.Add( "Lai Châu" );
                        current.Add( "Lạng Sơn" );
                        current.Add( "Lào Cai" );
                        current.Add( "Lâm Đồng" );
                        current.Add( "Long An" );
                        current.Add( "Nam Định" );
                        current.Add( "Nghệ An" );
                        current.Add( "Ninh Bình" );
                        current.Add( "Ninh Thuận" );
                        current.Add( "Phú Thọ" );
                        current.Add( "Phú Yên" );
                        current.Add( "Quảng Bình" );
                        current.Add( "Quảng Nam" );
                        current.Add( "Quảng Ngãi" );
                        current.Add( "Quảng Ninh" );
                        current.Add( "Quảng Trị" );
                        current.Add( "Sóc Trăng" );
                        current.Add( "Sơn La" );
                        current.Add( "Tây Ninh" );
                        current.Add( "Thái Bình" );
                        current.Add( "Thái Nguyên" );
                        current.Add( "Thanh Hóa" );
                        current.Add( "Thừa Thiên - Huế" );
                        current.Add( "Tiền Giang" );
                        current.Add( "Trà Vinh" );
                        current.Add( "Tuyên Quang" );
                        current.Add( "Vĩnh Long" );
                        current.Add( "Vĩnh Phúc" );
                        current.Add( "Yên Bái" );
                    }
                return current;
            }

        }
        public ProvinceCollection()
            : base()
        { }
    }
}

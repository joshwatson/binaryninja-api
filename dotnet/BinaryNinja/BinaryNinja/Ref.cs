//using System;

//namespace BinaryNinja
//{
//    public class Ref<T> where T : class
//    {
//        private T m_object;

//        public Ref(T _object)
//        {
//            m_object = _object;
//        }
        

//        public void Release()
//        {
//            m_object.Release();
//        }

//        public static implicit operator Ref<T>(T inner)
//        {
//            return new Ref<T>(inner);
//        }
//    }
//}
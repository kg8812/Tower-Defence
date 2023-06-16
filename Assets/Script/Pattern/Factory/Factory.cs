using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class Factory<T> where T : Component
    {
        // 팩토리 추상 클래스
   
        public abstract T CreateNew(string Name); // 이름으로 오브젝트 생성
        public abstract T CreateRandom(); // 랜덤 오브젝트 생성
        public virtual void Return(T obj) // 오브젝트 반환
        {
            
            pool.Return(obj);
        }       

        protected ObjectPool<T> pool; // 오브젝트 풀

        public Factory(T[] objs) // 생성자, 인수로 오브젝트 생성할 프리팹 배열 입력
        {
            pool = new ObjectPool<T>(objs);
        }
    }

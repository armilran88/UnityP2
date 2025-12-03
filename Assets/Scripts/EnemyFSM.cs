using System;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    /*
    유한 상태 머신 (FSM)
    => 유한한 수의 상태(state)와 상태들 사이의 전환(transition)을 정의해서 
    시스템 동작을 하게 하는 것을 말하고 당연히 전환이 이루어 질려면 조건(condition)이 필요하다
    이것은 FSM 디자인 패턴이다.
    - 상태: 간단하게 행동들 (걷기, 달리기, 점프, 공격, 죽음 등등)
    - 전환: 상태에서 상태로 넘어가는 변화
    - 조건: 전환이 발생하기 위한 필요한 기준 (키입력, HP감소, 특정 아이템을 획득 등 다양한 이벤트)
    => 결론은 이미 여러분은 애니메이터를 사용하면서 한번씩은 겪어 봤다

    => 플레이어 캐릭터 행동 제어
    => 대표적으로 에너미 AI 구현
    => 예) 몬스터가 플레이어를 발견하기 전에는 (순찰)상태, 플레이어를 발견하면 (추격)상태,
    공격범위안에 들어오면 (공격)상태, HP가 일정이하로 떨어졌을때 (도망, 버서커)
    */


    //몬스터 상태 이넘문
    enum EnemyState
    {
        Idel, Move, Attack, Return, Damaged, Die
    }

    EnemyState state;       //몬스터 상태 변수

    public float findRange = 15f;       //플레이어를 찾는 범위
    public float moveRange = 30f;       //시작지점에서 최대 이동가능한 범위
    public float attackRange = 2f;      //공격 가능 범위

    //애니메이션을 제어하기 위한 에니메이션 컴포넌트
    //Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //몬스터 상태 초기화
        state = EnemyState.Idel;
    }

    // Update is called once per frame
    void Update()
    {
        //상태에 따른 행동처리
        switch(state)
        {
            case EnemyState.Idel:
                Idel();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
        
    }

    //대기상태
    private void Idel()
    {
        //1. 플레이어와 일정범위가 되면 이동상태로 변경 (탐지범위)
        //- 플레이어 찾기
        //- 일정거리 비교 (Distance, magnitude, sqrMagnitue 아무거나)
        //- 상태변경 state = EnemyState.Move;
        //- 상태전환 출력 print("Idle -> Move");
        //- 애니메이션 anim.SetTrigger("Move");
    }

    //이동상태
    private void Move()
    {
        //1. 플레이어를 향해 이동 후 공격범위 안에 들어오면 공격상태로 변경
        //2. 플레이어를 추격하더라도 처음위치에서 일정범위를 넘어가면 리턴상태로 변경
        //- 플레이어 처럼 캐릭터 컨트롤러 이용하기 (cc.Move 대신 cc.SimpleMove 이용하자)
        //- 공격범위 2미터
        //- 상태변경
        //- 상태전환 출력
        //- 애니메이션
    }

    //공격상태
    private void Attack()
    {
        //1. 플레이어가 공격범위 안에 있다면 일정한 시간 간격으로 플레이어 공격
        //2. 플레이어가 공격범위를 벗어났다면 이동상태(재추격)로 변경
        //- 공격범위 2미터
        //- 상태변경
        //- 상태전환 출력
        //- 애니메이션
    }

    //복귀상태
    private void Return()
    {
        //1. 몬스터가 플레이어를 추격하더라도 처음 위치에서 일점 범위를 벗어나면 다시 돌아옴
        //- 처음 위치에서 일정범위 30미터
        //- 상태변경
        //- 상태전환 출력
        //- 애니메이션
    }

    //플레이어쪽에서 충돌감지를 할 수 있으니 이함수는 퍼블릭으로 만들자
    public void HitDamage(int value)
    {
        //예외처리
        //피격상태거나, 죽은상태일때는 데미지 중첩으로 주지 않는다


        //체력깎기
        //몬스터 체력이 1이상이면 피격상태
        //0이하면 죽음상태
    }


    //피격상태 (Any State)
    private void Damaged()
    {
        //1. 몬스터 체력이 1이상
        //2. 다시 이전상태로 변경
        //- 상태변경
        //- 상태전환 출력

        //피격상태를 처리하기 위해서는 간단한 코루틴 사용하자
    }

    //죽음상태 (Any State)
    private void Die()
    {
        //1. 체력이 0이하
        //2. 몬스터 오브젝트 삭제
        //- 상태변경
        //- 상태전환 출력

        //진행중인 모든 코루틴은 정지 한다 
        StopAllCoroutines();
        //죽음상태를 처리하기 위해서는 간단한 코루틴 사용하자
    }
}

#  Unity 개인 과제 - 3D 스파르타 던전 탐험 

본 프로젝트는 Unity를 기반으로 하여 주어진 필수 기능들을 구현한 개인 과제입니다. 아래의 기능들을 중심으로 구현되었습니다.

## 🛠️ 주요 구현 기능

###  기본 이동 및 점프 (`Input System')
- 플레이어는 `WASD` 키로 이동, `Space` 키로 점프 'Mouse Left Button'키로 공격할 수 있습니다. 인벤토리 활성화는 'tab'키 입니다.

###  스테이터스바 UI (`Canvas`, `Square Image`)
- Canvas에 `Square Image`를 이용하여 스테이터스바 구성.
- 플레이어의 스테이터스이 변화할 때마다 실시간으로 상태 UI 업데이트.

###  동적 환경 조사 (`Raycast`, `UI`)
- 플레이어 시야 전방에 있는 오브젝트를 `Raycast`로 감지.
- 해당 오브젝트의 **이름**과 **설명**을 UI Text에 실시간 표시.

###  점프대 (`Rigidbody`, `ForceMode.Impulse`)
- 특정 발판을 밟으면 캐릭터가 위로 튀어 오르는 점프대 구현.
- `OnCollisionEnter`를 통해 점프대 감지, `ForecMode.Impulse`로 힘 적용.

###  아이템 데이터 관리 (`ScriptableObject`)
- 다양한 아이템 정보(이름, 설명, 효과 등)를 `ScriptableObject`로 관리.
- 새로운 아이템을 쉽게 추가하거나 수정할 수 있도록 설계.

###  아이템 사용 및 효과 (`Coroutine`)
- 아이템 사용 시, **일정 시간 동안** 효과가 지속되도록 `Coroutine`으로 구현.
- 예시: 이동속도 증가 아이템 → `BoostSpeedCoroutine` 실행 후 원상복귀.

---

## 🎮 조작 방법

| 키 | 동작 |
|----|------|
| W/A/S/D | 이동 |
| Space | 점프 |
| 마우스 | 시야 이동, 공격 |
| Tab | 인벤토리 |
| E | 상호 작용 |
---

## 📁 프로젝트 구조 (일부)

Assets/
├── Scripts/
│ ├── _UI
│ ├──── ItemSlot.cs
│ ├──── UIConditions.cs
│ └──── UIInventory.cs
│ ├── InteractableObject
│ ├──── ItemObject.cs
│ └──── Resource.cs
└── ScriptableObjects
├── Data.Folder
└── ItemData.cs (Scriptable Object)

## 📷 데모 영상 / 스크린샷
> 

https://github.com/user-attachments/assets/b9f403db-5db3-4430-ad0a-e71da0e60ea2

---

## 💡 학습 포인트

- Unity에서 **물리 기반 이동과 UI 시스템**의 연동 경험
- `Coroutine`과 `ScriptableObject`의 실제 사용법 숙지
- 게임 오브젝트의 동적 감지와 반응 처리 (`Raycast`, `OnTriggerEnter`, `OnCollisionEnter`)

---

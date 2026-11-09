# Unity Convention  

## 기본 폴더 구조

```
Assets
├─ Animations
├─ Fonts
├─ Images
├─ Materials
├─ InputAction
├─ Prefabs
│  ├─ Player
│  └─ Monster
├─ Scenes
└─ Scripts
   ├─ Player
   ├─ Monster
   └─ UI
```

### 폴더별 사용
|파일명|파일내용|
|---|---|
|Animations|Animation Clip, Animator 관련 파일|
|Fonts|프로젝트에서 사용하는 Font|
|Images|프로젝트에서 사용하는 .png 파일|
|Materials|Material 관련 파일|
|Prefabs|만든 Prefab 파일|
|Scenes|Unity Scene|
|Scripts|C# Script|

- Prefabs 폴더에서 Prefab 만들시 종류따라 폴더를 만들어 Prefab을 만든다.(예: 몬스터 Prefab을 만들면 몬스터 폴더를 만들어 몬스터 Prefab을 만든다.)
- Scripts 폴더에서 Script만들시 종류를 따라 폴더를 만들어 Script을 만든다.(예: Player 이동 스크립트 구현시 Scripts 폴더에서 Player폴더를 만들어 Player관련 스크립트만 구현하여 구분한다.)
- InputAction파일은 Input 에셋을 둔다.

#### Scene 규칙 
- 다른 작업자가 만든 Scene은 사용하지 않는다.
- 개인 작업물 테스트 Scene이 필요한 경우 Test로 이름은 짓는다.(예: Player 기능을 테스트 한다면 PlayerTest로 짓는다.)
- 테스트 Scene을 필요 할때마다 무작정 만들지 않는다.(플레이어 기능이 추가 되어 테스트 한다면 기존 플레이어 테스트 Scene 재사용 한다. 플레이어 테스트 Scene에서 몬스터도 만들어 플레이와 상호작용 테스트를 진행했다면 PR 명시한다.)
- 공용 Scene을 수정해야 한다면 사용자 승인을 받는다. (최대한 다른 작업자 Scene 사용하지 않는다.)
- 기능 구현후 참조가 필요하면 사용자에게 묻고 승인 받는다.
- 컴포넌트를 추가했다면 사용자에게 알린다.
- Scene 변경 사항이 있다면 PR에 명시한다

#### Prefab 규칙  
- Prefab 만들면 용도를 알 수 있도록 작성한다. (예: 몬스터를 만들었으면 Monster 이라고 이름을 짓는다.)  
- 다른 작업자의 Prefab은 임의로 삭제하거나 수정하지 않는다. (수정이 꼭 필요한 경우 확인을 받거나 따로 Original Prefab으로 새로 만들어 사용.)
- 기존 Prefab의 컴포넌트를 제거하거나 구조를 변경할 때는 영향 범위를 확인한다.

#### Script 작성 규칙
- 클래스 이름과 파일 이름을 동일하게 작성한다.

## Unity 파일 관리
- .meta 파일은 임의로 삭제하거나 수정하지 않는다.
- `.gitignore` 파일은 임의로 삭제하거나 수정하지 않는다. (절대 건들지 않는다.)
- 본인 작업과 관계없는 파일을 Commit하지 않는다.
- Assets 안의 최상위 폴더를 임의로 생성하거나 삭제하지 않는다.( 필요한 경우나 파일이 존재하지 않으면 사람에게 요청해서 확인받고 생성.)

## 프로젝트 설정 관리
- Unity 버전을 임의로 변경하지 않는다.  
- 패키지 추가·삭제 및 프로젝트 전역 설정 변경은 사용자 승인 후 진행한다.  

## 작업 완료 확인  
- C# 컴파일 오류 여부 확인한다.
- Console Error 확인한다.
- 구현한 기능과 기존 기능이 충돌하거나 정상 동작 하는지 확인한다.
- 수정한 Scene과 Prefab의 참조 누락 여부 확인한다.
- 기능 동작이 동작하거나 오류가 없지만 Unity Editor에서 확인이나 검증이 불가 하다면 미검증 상태라고 명시한다.
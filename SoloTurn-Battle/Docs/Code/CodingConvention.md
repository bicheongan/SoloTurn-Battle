# Coding Convention

## 기본 원칙
- 기존 코드의 기능과 구조를 최대한 유지한다.
- 요청한 작업과 관계없는 코드는 임의로 수정하거나 리팩토링하지 않는다.
- 새로운 설계 방식이나 디자인 패턴 도입이 필요한 경우 이유를 설명하고 사용자에게 확인받는다.
- 코드는 읽기 쉽고 역할을 이해할 수 있도록 작성한다.

## 네이밍 규칙
|구분|규칙|예시|
|---|---|---|
|클래스|PascalCase|MonsterHealth|
|인터페이스|I + PascalCase|IDamageable|
|메서드|PascalCase|TakeDamage()|
|프로퍼티|PascalCase|Waypoints|
|private 필드|_camelCase|_moveSpeed|
|매개변수|camelCase|damageAmount|
|지역 변수|CamelCase|CurrentHealth|
|상수|UPPER_SNAKE_CASE|MAX_HP|

- 이름만 보고 역할을 알 수 있도록 작성한다.
- 클래스 이름과 C# 파일 이름을 동일하게 작성한다.
- 약어 또는 의미가 불분명한 이름은 가능한 사용하지 않는다.
- bool타입 변수 선언시 Is,Can,Has 말머리가 들어간다. (예: IsDead, CanJump)
 - private 으로 선언 했다면 `_isDead` 로 선언한다.

## 코드 작성 스타일
- 클래스, 메서드, 조건문 등의 여는 중괄호 `{`는 다음 줄에 작성한다.
- 한 메서드는 가능한 한 하나의 명확한 역할을 수행하도록 작성한다.
- 사용하지 않는 `using` 문과 변수는 정리한다.
- 기존 코드와 관계없는 스타일 변경만을 위한 수정은 하지 않는다.

## 접근 제한자
- 필드는 기본적으로 `private`으로 작성한다.
- Inspector에서 설정해야 하는 필드는 가능한 `[SerializeField] private`을 사용한다.
- 외부에서 접근이 필요한 값은 목적에 맞는 public 메서드 또는 프로퍼티를 제공한다.
- 외부에서 변경할 필요가 없는 데이터는 가능한 읽기 전용으로 노출한다.
- `public` 필드는 꼭 필요한 경우에만 사용한다.

## 클래스 및 인터페이스 규칙
- 클래스는 담당하는 역할을 명확히 한다.
- 상속, 추상 클래스, 인터페이스는 필요성이 있을 때 사용한다.
- 기존 코드에 없는 복잡한 구조나 디자인 패턴을 이유 없이 추가하지 않는다.
- 공통 기능을 분리할 때 기존 코드와의 호환성을 확인한다.

## Unity C# 작성 규칙
- Unity 생명주기 메서드(`Awake`, `Start`, `Update` 등)는 필요한 경우에만 사용한다.
- 매 프레임 확인할 필요가 없는 처리는 불필요하게 `Update`에 넣지 않는다.
- 컴포넌트 참조는 필요한 시점에 확보하고, 반복적인 검색 호출은 피한다.
- `MonoBehaviour`의 필드와 Inspector 연결을 변경할 때 Scene 및 Prefab 참조에 영향을 주는지 확인한다.
- Unity 프로젝트의 Scene, Prefab, 파일 관리 및 설정 변경은 `Docs/UnityConvention.md`를 따른다.
- `InputSystem`을 사용시 `InputActionReference`로 코드를 작성한다.
- `GetComponent` 참조할시 `CacheComponents()` 메서드를 만들어 모아서 참조한다.
- `BindInputEvents()`메서드는 한번에 처리 해도 문제 없는 구독은 모아서 사용한다. 
- `UnbindInputEvents()`메서드는 한번에 처리 해도 문제 없는 구독해제는 모아서 사용한다.
- `InputSystem` 으로 이동 구현시 Action Type는 Value, Control Type는 Vector2로 만든다. (직접 읽기로 구현)
- Tag는 사용하지 않고 LayerMask로 구현한다. Tag는 꼭 필요한 경우에만 사용한다.

## 주석 작성 규칙
- 코드만으로 의도가 명확하지 않은 부분에 주석을 작성한다.
- 코드 내용을 그대로 반복하는 불필요한 주석은 작성하지 않는다.
- 기존 주석은 코드 변경으로 의미가 달라진 경우에만 수정한다.

## 기존 코드 수정 규칙
- 수정 전에 관련 코드를 확인하고 기존 동작을 유지한다.
- 요청한 기능 구현에 필요한 범위만 수정한다.
- 기존 공개 API, 직렬화 필드 이름, 클래스 이름 등을 변경할 경우 참조에 미치는 영향을 먼저 확인한다.
- 기존 스타일이 본 컨벤션과 다른 경우 관련 없는 부분까지 일괄 변경하지 않는다.
- 작업 후 가능한 범위에서 컴파일 오류 및 기능 동작을 확인한다.
- Unity Editor에서 직접 확인하지 못한 내용은 검증했다고 주장하지 않고 미검증으로 명시한다.
- Issue, Branch, Commit, Pull Request 및 Merge 절차는 `Docs/GitConvention.md`를 따른다.
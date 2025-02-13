![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&size=50&pause=1000&width=635&height=100&lines=Sparta+Team+Text+RPG)
---

# Description
 - **프로젝트 소개** <br>
   4인 팀 프로젝트로 진행한 Text RPG 입니다.<br>
   팀원들과 프로젝트를 공유하며, 파일의 충돌을 줄이기 위해 소통에 집중하여 작업했습니다.<br>
   팀원들과 함께 모든 도전 과제를 구현해보는 것을 목표로 개발했습니다. <br><br>
 - **개발 기간** : 2025.02.06 - 2025.02.13
 - **참여 인원**<br>
   팀장 - 김영송<br>
  팀원 - 이건우<br>
  팀원 - 이중석<br>
  팀원 - 예병권<br>
<br><br>

---
# 핵심 기능
- 플레이어 상태 보기<br>
- 인벤토리 시스템 (아이템 장착 관리)<br>
- 상점 (아이템 구매, 판매)<br>
- 휴식 기능<br>
- 던전 시스템<br>
- 게임 저장 기능<br>
- 스킬 시스템
- 퀘스트 시스템
<br><br>

---
# 와이어 프레임
![image](https://github.com/user-attachments/assets/289071f9-46d9-4644-abd0-1e4cfc0151b8)
- 각 Scene을 Town Class에서 진입 할 수 있게 했습니다.
- 각 Scene에서 사용하는 Data들을 DataManager를 통해 사용할 수 있도록 설계했습니다.
- 팀 작업간 DataMaanger의 충돌 문제를 줄이기 위해 Partial Class 기능을 이용했습니다. 
<br><br><br>

---
# 주요 Scene
## 로비
![banner](https://github.com/user-attachments/assets/60401f64-2e3f-46e4-94b3-fda340c4ca89)
<br><br>
## 새 게임
![image](https://github.com/user-attachments/assets/fe7bea8f-8716-4512-a9ae-805f057f1255)
<br><br>
## 캐릭터 생성
![image](https://github.com/user-attachments/assets/8c5c2dac-f15e-4d28-9f58-78864c552846)
<br><br>
## 직업 선택
![image](https://github.com/user-attachments/assets/f7857825-0810-492b-a21a-4b714a90a5ac)
<br><br>
## 마을
![image](https://github.com/user-attachments/assets/c8fd2de3-8368-46e9-9047-4c06a10a2c2b)
<br><br>
## 상태 Scene
![image](https://github.com/user-attachments/assets/e7d2041d-0dda-4053-8d6c-a74f9f2d5320)
<br><br>
## 회복 Scene
![image](https://github.com/user-attachments/assets/50a97722-a9d7-4ec1-a3d5-4218030a64ce)
<br><br>
## 상점 Scene
![image](https://github.com/user-attachments/assets/7630e221-6bd5-4923-b8f3-9e8423e82578)
<br><br>
## 상점 - 아이템 구매
![image](https://github.com/user-attachments/assets/c727d3c9-62d9-4a11-abed-a606da732a7b)
<br><br>
## 상점 - 아이템 판매
![image](https://github.com/user-attachments/assets/fca2a629-58ac-457c-8e23-088ac16f3df8)
<br><br>
## 인벤토리 Scene
![image](https://github.com/user-attachments/assets/95f3a468-c245-4d3a-9a8d-f9a66ce315c2)
<br><br>
## 퀘스트 Scene
![image](https://github.com/user-attachments/assets/aa55696f-c064-47f6-9645-efe6073a3cd5)<br>
![image](https://github.com/user-attachments/assets/ec409f17-4ab9-46a8-af4e-53b2c349c60d)
<br><br>
## 던전 Scene
![image](https://github.com/user-attachments/assets/19be11f1-4969-4867-b587-abeda808b394)
<br><br>
## 던전 - 전투
![image](https://github.com/user-attachments/assets/4356b789-dd56-4b30-84e2-55fcf2167208)
![image](https://github.com/user-attachments/assets/8d19ab74-2398-48d6-8306-b07acd1fde58)
<br><br>
## 던전 - 스킬
![image](https://github.com/user-attachments/assets/3ea00844-ed50-45c8-befe-5da28a068290)
![image](https://github.com/user-attachments/assets/23913462-acfb-4931-b029-4c432973992a)
<br><br>
## 저장 Scene
![image](https://github.com/user-attachments/assets/04efa3cb-f441-4298-a294-2b002ae9f974)
![image](https://github.com/user-attachments/assets/a40af67f-85c7-479a-95e2-18d2d1a91400)
![image](https://github.com/user-attachments/assets/ef6d3f3b-ed6f-434f-8b14-4a6602f06472)
<br><br><br>

---

# 핵심 구현 로직 설명
 ## Scene 관리
  ![image](https://github.com/user-attachments/assets/eed81dd4-3f50-4724-a02b-7fa754580687)
  - 각 기능들을 Scene 단위로 분할하여 작업 했습니다.<br><br>
 ![image](https://github.com/user-attachments/assets/c55a3628-945e-42d6-9210-f7fd490efd5a)<br>
  - Scene 클래스는 추상 클래스로 만들었으며 EnterScene 함수가 호출되면 각 기능들이 시작되도록 설계했습니다.<br>
  interface로도 구현이 가능하지만, interface의 경우 변수를 지정할 수 없다는 특징이 있기에 추상 클래스 기능을 이용했습니다. <br>
<br><br>

## 유저의 입력
 ![image](https://github.com/user-attachments/assets/8c04ee2c-a9d8-4b28-9a98-05620efa81d6)
 - 게임 플레이 중에는 숫자를 통해 옵션을 선택하는 기능을 많이 사용하게 됩니다. <br>
   모든 곳에서 해당 기능을 구현하는 것은 유지 보수 측면에서 좋지 않다고 생각했고 <br>
   static 함수로 만들어서 자유롭게 호출할 수 있도록 구현했습니다.<br>
- Enter를 통해 키를 입력하는 것이 아니 실시간으로 입력되는 키를 체크하는 방식으로 입력을 받도록 했습니다.
<br><br>


## 퀘스트 데이터
![image](https://github.com/user-attachments/assets/39f6e685-349a-4d78-801f-882f5b43beec)<br>
![image](https://github.com/user-attachments/assets/2114230a-766e-43ff-b3ce-d5b11ccf486c)
- 퀘스트를 모듈 형식으로 쉽게 조립할 수 있도록 설계했습니다. <br>
  QuestData는 퀘스트를 설명하는 name, description과 보상을 의미하는 gold, items, <br>그리고 퀘스트의 상태를 표시하는 state를 보관합니다.<br>
- 그리고 퀘스트의 작업을 의미하는 Quest Task를 List의 형태로 저장하고 있습니다. 이 class를 통해서 퀘스트의 작업을 구현했습니다.
<br><br>

### 
![image](https://github.com/user-attachments/assets/a233d314-1e7c-4cbf-8641-40d81845a29d)<br>
![image](https://github.com/user-attachments/assets/f87d935b-8903-4fe0-b4c7-5f9027d71361)
- Quest Task에는 해당 작업의 이름과 목표로하는 개수 Target Cnt, 현재 개수 Current Cnt 변수를 저장하고 있습니다. <br>
미니언 5마리를 잡는 퀘스트를 예로 들면 Target Cnt는 5가 됩니다. <br>
- 또한 ETaskType을 통해 작업들을 관리하도록 했습니다.

### 
![image](https://github.com/user-attachments/assets/3fc0055a-9797-416c-8d15-3786fbc6ef6e)<br>
- Quest Task는 Dictionary에서 ETaskType을 Key로 하여 저장 되고 있습니다.
### 
![image](https://github.com/user-attachments/assets/884be012-cedb-4e6f-929a-06109cf822e7)
- ReportTask 함수에 ETaskType을 인자로 보내고 해당 타입에 맞는 QuesTTask의 ProgressTask함수를 호출하게 됩니다. <br>
해당 함수를 통해 Quest Task의 Current Cnt 가 + num 되며 작업의 진행도를 업데이트 할 수 있습니다.
### 
![image](https://github.com/user-attachments/assets/ca98e7de-8681-4e40-b0d8-86b63ccf6c98)
- 몬스터의 생성자에 람다식을 통해 ReportTask 함수를 호출되도록 넣어주었으며, 해당되는 퀘스트의 TaskType을 인자로 넣어주었습니다.
### 
![image](https://github.com/user-attachments/assets/50bc7c47-2af9-4c68-b0fc-f2dc9993a1c2)
- 그럼 해당 함수는 Monster의 onDie Action에 추가되며<br>
### 
![image](https://github.com/user-attachments/assets/79d2cd4d-14a2-479f-bf75-a6e390ea08b1)
- 몬스터의 Hp가 0이 될 때, 호출되도록 했습니다.
<br><br>
- 즉, 저희가 구현한 퀘스트 시스템의 핵심은 작업의 진행도를 퀘스트 데이터에서 판단하는 것이 아니라 <br>
  각 행동들이 이루어지는 곳에서 퀘스트 데이터에 보고하도록(ReportTask) 만든 것 입니다.
<br><br><br>

## 스킬 시스템
![image](https://github.com/user-attachments/assets/0fb106a5-456d-41c4-948f-77b8c86c526c)
- 추상 클래스를 통해 Skill을 만들었습니다.<br>
  스킬을 설계할 때, List에 모든 스킬을 넣고, 반복문을 통해 출력, List에 인덱싱하여 하나의 함수를 통해<br>
  모든 종류의 스킬을 사용할 수 있게 하는 것이 목표였습니다.<br>
- 때문에 추상클래스 기능을 이용했습니다. Skill 클래스를 상속받은 후, OnSkill 클래스를 재정의 하는 방식으로 위의 목표를 달성했습니다.
###
![image](https://github.com/user-attachments/assets/ea45ed0c-6a9e-4499-883f-b3b10337fafa)
![image](https://github.com/user-attachments/assets/3a755ea0-f24d-46c3-b99f-55ea4242acae)


<br><br>
## Ascii Art
![image](https://github.com/user-attachments/assets/a999dc46-e0bd-4232-87f8-e5061aa07b66)
- 아스키 아트를 이용해서 배너가 뜨도록 만들었습니다. 
- 왼쪽으로 이동하는 모습을 구현하기 위해 실시간으로 배너를 업데이트했습니다.

![image](https://github.com/user-attachments/assets/5cb46478-31f9-4ee4-869f-c06f44009d4c)
![image](https://github.com/user-attachments/assets/ad140dee-7f16-44cc-ba90-e842955c5aee)


# 감사합니다.
  

 


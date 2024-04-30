# 자동차 엔진 조립을 위한 실시간 모니터링 및 관리 시스템

## 개발 주제
자동차 엔진 조립을 위한 실시간 모니터링 및 관리 시스템 개발

## 학습 목표 및 적용
- **C#과 .NET 활용**: C#을 활용한 Windows Forms 애플리케이션 개발에 숙련되어 다양한 실시간 데이터 처리와 사용자 인터페이스 디자인을 실무에 적용함으로써, 효율적인 소프트웨어 솔루션 구축 능력을 키움.
- **RDBMS 활용**: SQL Server를 중심으로 데이터 관리 및 조작에 대한 깊은 이해를 바탕으로, 데이터의 안정적인 저장, 접근 및 분석 능력을 강화함. 이를 통해 데이터 주도 의사결정을 지원하는 강력한 데이터베이스 시스템 설계 및 구현.

## 프로그램 개요
- 기반 기술: C# 프로그래밍 언어와 SQL Server 데이터베이스
- 시스템 설계: 자동차 제조 공정의 핵심 부분인 엔진 조립 라인의 효율성과 생산성 극대화
- 기능: 실시간 데이터 수집 및 분석을 통해 생산 라인의 성능 모니터링, 잠재적 문제 즉시 감지 및 대응, 공정의 안정성과 제품 품질 보장

## 주요 기능
- **실시간 알람 관리**: 설비의 이상 징후나 오류를 실시간으로 감지하고 사용자에게 알림 제공
- **대시보드를 통한 데이터 시각화**: 생산 데이터를 직관적인 대시보드로 시각화하여 관리자가 실시간으로 공정 상태 파악 및 필요 조치 실행
- **품질 관리**: 제품의 불량률 및 기타 성능 지표 계산으로 품질 관리 및 생산 효율성 향상
- **사용자 친화적 인터페이스**: 사용하기 쉬운 인터페이스와 다양한 입력 폼 제공으로 데이터 쉽게 입력 및 관리

## 프로젝트 상세 설명 및 역할
### 메인 페이지
![스크린샷 2024-04-30 132327](https://github.com/kimgayoung0114/SmartFactory/assets/154950352/c49bc782-eae2-4cac-97e0-4732ba7e10f9)
### 1. 설비정보
- **기능**: 제품 정보 및 생산 관련 데이터를 관리. 사용자는 제품 정보를 추가, 수정, 삭제할 수 있으며, 각 제품의 생산 상태를 조회할 수 있음
- **역할**: CRUD 기능을 구현하여 제품 데이터를 관리. 데이터 그리드와 콤보 박스를 활용하여 사용자가 데이터를 쉽게 조작할 수 있도록 인터페이스 설계
![스크린샷 2024-04-29 125032](https://github.com/kimgayoung0114/SmartFactory/assets/154950352/83475db7-f78d-4b57-ab8d-f91ed13c11c8)
### 2. 작업자 마스터
- **기능**: 작업자 및 작업 지시 정보를 관리
- **역할**: 작업자 정보에 대한 CRUD 기능을 구현하고, 데이터베이스와의 연동을 통해 정보를 실시간으로 업데이트. 사용자가 데이터를 쉽게 수정할 수 있도록 트랜잭션 관리를 포함한 데이터 저장 로직 구현
![스크린샷 2024-04-30 105311](https://github.com/kimgayoung0114/SmartFactory/assets/154950352/dc9af433-139a-4472-9477-daec3b62786a)
### 3. 설비운영현황
- **기능**: 설비의 작동 상태를 실시간으로 모니터링하고, 전압 수준이 특정 임계값을 초과하면 알람을 발생
- **역할**: 타이머를 사용하여 주기적으로 설비의 상태를 확인하고, 조건에 따라 데이터베이스에 알람 로그를 기록하거나 사용자 인터페이스에 경고를 표시. 데이터 검색 및 저장 로직을 구현.
![스크린샷 2024-04-30 105456](https://github.com/kimgayoung0114/SmartFactory/assets/154950352/70450b24-5ca7-422a-8f53-cf73d0670017)
### 4. 알람
- **기능**: 실시간으로 발생하는 알람을 관리하고 표시. 사용자는 발생한 알람의 상세 정보를 조회할 수 있으며, 필터링 기능을 통해 특정 설비 라인 또는 품목에 대한 알람만 볼 수 있음.
- **역할**: 알람 데이터를 데이터베이스에서 조회하고, 결과를 DataGridView 및 차트로 시각화. 콤보 박스를 통해 사용자가 알람을 필터링할 수 있도록 구현. 

### 5. 대시보드
- **기능**: 공장 전체의 생산 통계를 대시보드 형태로 제공. 불량률, 생산률 등의 KPI(핵심성과지표)를 시각화
- **역할**: 데이터베이스에서 생산 데이터를 집계하고, 이를 바탕으로 차트를 동적으로 생성하여 생산 성과를 분석. 또한, 공정별 불량률을 계산하여 대시보드에 표시

## 기대효과
- 생산 라인의 효율성 증대
- 설비별 정보를 통한 목표 달성률 파악
- 향상된 제품 품질

## 겪었던 어려움과 극복 과정
프로젝트 발표 일주일 전부터는 수업이 끝난 뒤 오후 10시까지 학교에 남아 프로젝트 작업을 이어갔습니다. 주말도 예외는 아니었고, 새벽부터 밤늦게까지 프로젝트에 몰두했습니다.

  이 같은 강도 높은 일정이 지속되면서 체력적, 정신적 한계에 도달하는 순간도 있었습니다. 그러나 일과 중 2시간마다 10분씩 외부로 나가 신선한 공기를 마시며 산책을 즐기고, 좋아하는 음악을 들으며 재충전의 시간을 가졌습니다. 이는 마음의 여유를 되찾고, 더욱 집중력을 높여 효율적으로 문제를 해결해 나가는 데 큰 도움이 되었습니다.

  이러한 경험은 저에게 스트레스 관리 방법뿐만 아니라, 집중력 유지와 효율적인 시간 활용법에 대한 귀중한 교훈을 주었습니다. 무엇보다, 이 과정에서 얻은 끈기와 인내는 제 개인적 성장에 중요한 자산이 되었습니다.

# Book Manager
WinForms 기반의 도서 관리 프로그램입니다.
사용자가 직접 책 정보를 추가, 수정, 삭제 검색할 수 있으며, SQL Server와 연동하여 데이터를 저장합니다.


## 개발환경
- 언어: C# 12  
- 프레임워크: .NET 8.0  
- UI: Windows Forms (WinForms)  
- DB: SQL Server  
- IDE: Visual Studio 2022  

## 주요기능
- 도서 목록 조회
- 도서 등록 (Create)
- 도서 정보 수정 (Update)
- 도서 삭제 (Delete)
- 도서 검색
- SQL Server 연동 (ADO.NET 사용)

## 구조
UI 관련 코드는 `Forms/`
DB 관련 로직은 `Data/`
비즈니스 모델 클래스는 `Models/`


## 트러블슈팅

### System.Data.SqlClient 관련 클래스 인식 불가
System.Data.SqlClient 관련 클래스 인식 불가  
.NET 6 이상에서는 System.Data.SqlClient가 기본 포함되지 않음. → NuGet 패키지로 따로 설치해야 함.  
https://learn.microsoft.com/ko-kr/nuget/quickstart/install-and-use-a-package-in-visual-studio


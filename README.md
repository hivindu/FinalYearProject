# Online Road Maintenance Issue Reporting System Web Services


> Why is this repository ?
  - This is the project that i have done for my final year project. Currently in sri lanka there is no proper way of reporting road maintenance issues. Based on the survey and the research that i have carried out on the internet, I have found that many people dose not know of the current process of reporting issues. So i decided to develop this application as my sole final year project in my degree program. This application has developed based on Service Oriented Architecture. There are five services and one APi gateway.

> What is Online Road Maintenance Issue Reporting System ?
  - Online plateform that is used by citizens of a country to report maintenance issue on road.

> What are the technologies that i have used to develop ?

- .Net core 3.1
- Docker
- Ocelot API gateway
- Swagger API documentation
- Digital Ocean APP platform
- MmongoDB

> What are the URLs for docker images ?

  - [Issue Service](https://hub.docker.com/r/hivi99/issueapi)
  - [User Service](https://hub.docker.com/r/hivi99/userapi)
  - [UcRDA User Serivce](https://hub.docker.com/r/hivi99/ucrdausersapi)
  - [Approve Service](https://hub.docker.com/r/hivi99/approveapi)
  - [Work Assign Service](https://hub.docker.com/r/hivi99/workassignapi)
  - [API Gateway](https://hub.docker.com/r/hivi99/apigateway)

> What are the prerequisite for this solution ?

- [Download](https://visualstudio.microsoft.com/downloads/) and Install Visualstudio 2019
- [Download](https://docs.docker.com/docker-for-windows/install/) and Install Docker Desktop

> How to run this application Successfully ?
- clone this repository to visual studio 2019
- Build the solution
- Right click on the Docker compose file in the solution -> click open in file explorer
- Type ```cmd ``` on url line of the file explore
- ``` docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d ``` on prompted command line **Make sure Docker desktop is up and running**

Another way we can run this application by pulling docker images from my docker hub repository links that i have provided in above.


**Thank You & Happy Coding :smiley:!**

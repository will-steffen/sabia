# Host: 40.117.230.30  (Version 5.7.24-0ubuntu0.16.04.1)
# Date: 2018-11-05 14:24:11
# Generator: MySQL-Front 6.0  (Build 3.3)


#
# Structure for table "__EFMigrationsHistory"
#

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for table "__EFMigrationsHistory"
#

INSERT INTO `__EFMigrationsHistory` VALUES ('20181103145419_User','2.1.4-rtm-31024'),('20181103155423_skill','2.1.4-rtm-31024'),('20181103155813_skill-2','2.1.4-rtm-31024'),('20181103160039_skill-3','2.1.4-rtm-31024'),('20181103163124_skill-unique-name','2.1.4-rtm-31024'),('20181103170102_user-skill','2.1.4-rtm-31024'),('20181103170336_user-skill2','2.1.4-rtm-31024'),('20181103205047_version-1','2.1.4-rtm-31024'),('20181103212402_nullable-fks','2.1.4-rtm-31024'),('20181103225630_float-values','2.1.4-rtm-31024'),('20181104000904_nullable-user-id-jobs','2.1.4-rtm-31024'),('20181104012547_hours-to-user','2.1.4-rtm-31024'),('20181104013944_monay','2.1.4-rtm-31024'),('20181104022022_text-fields','2.1.4-rtm-31024'),('20181104033004_bugfix','2.1.4-rtm-31024'),('20181104042805_esthourscol','2.1.4-rtm-31024'),('20181104045126_extdesc','2.1.4-rtm-31024');

#
# Structure for table "CourseTypes"
#

DROP TABLE IF EXISTS `CourseTypes`;
CREATE TABLE `CourseTypes` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) DEFAULT NULL,
  `Basic` bit(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

#
# Data for table "CourseTypes"
#

INSERT INTO `CourseTypes` VALUES (1,'Basic Web',b'1'),(2,'Html',b'0'),(3,'Css',b'0'),(4,'Javascript',b'0'),(5,'Linux',b'0'),(6,'Computer Basics',b'1'),(7,'GoLang',b'0'),(8,'Basic SQL',b'0'),(9,'SQLServer',b'0');

#
# Structure for table "Courses"
#

DROP TABLE IF EXISTS `Courses`;
CREATE TABLE `Courses` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `ExpectedHours` float NOT NULL,
  `CourseTypeId` bigint(20) NOT NULL,
  `Level` int(11) NOT NULL,
  `RequirementCourseId` bigint(20) DEFAULT NULL,
  `ImagePath` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Courses_CourseTypeId` (`CourseTypeId`),
  KEY `IX_Courses_RequirementCourseId` (`RequirementCourseId`),
  CONSTRAINT `FK_Courses_CourseTypes_CourseTypeId` FOREIGN KEY (`CourseTypeId`) REFERENCES `CourseTypes` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Courses_Courses_RequirementCourseId` FOREIGN KEY (`RequirementCourseId`) REFERENCES `Courses` (`id`) ON DELETE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

#
# Data for table "Courses"
#

INSERT INTO `Courses` VALUES (1,'Programação Web Básica','As linguagens de programação web são usadas especificamente para desenvolver sites',20,1,1,NULL,'aaa'),(2,'Html - Modulo 1','Entenda o HTML básico, saiba o que significa tags do HTML e entenda como fazer.',5,2,1,1,'aa'),(3,'Html - Modulo 2','Esse guia vai um pouco mais além do básico, acrescentando alguns detalhes práticos que vão melhorar a sua compreensão de HTML e permitir que você faça mais coisas.',12,2,2,2,'aa'),(4,'Css - Modulo 1','Esse tutorial o introduz ao Cascading Style Sheets (CSS) e aos seus recursos básicos com exemplos práticos.',12,3,1,1,'aaa'),(5,'Css - Modulo 2','Neste curso, apresentaremos algumas técnicas com CSS para criar páginas que abrem em qualquer tamanho de tela, se ajustando e se adaptando.',8,3,2,4,'aa'),(6,'Javascript - Modulo 1','Neste artigo veremos como utilizar o código Javascript em aplicações web e websites',20,4,1,1,'aaa'),(7,'Javascript - Modulo 2','Neste curso iremos apresentar funcionalidades mais avançados do JavaScript, permitindo que o aluno desenvolva pequenos sistemas web. ',20,4,2,6,'aaa'),(8,'Javascript - Modulo 3','Esse curso é destinado a estudantes e/ou desenvolvedores que já tenham conhecimento básico de JavaScript e querem melhorar o conhecimento nessa linguagem.',10,4,3,7,'aaa'),(9,'Javascript - Modulo 4','Una o paradigma orientado a objetos ao funcional para resolver problemas . Aplique novos recursos do ECMASCRIPT 6 . Estruture sua aplicação no modelo MVC.',22,4,4,8,'aaa'),(10,'Html - Modulo 3','Neste curso vamos aprender a utilizar os Data Attributes, um recurso do HTML 5 que permite definir atributos customizados nas tags.',12,2,3,3,'aaa'),(11,'Computação Básica','Curso que capacita o aluno nos conhecimentos básicos de informática, navegação na Internet, edição de textos, planilha eletrônica e apresentação de slides.',30,6,1,NULL,'aaa'),(12,'SQL Básico','Neste curso iremos ver os comandos básicos, descrever os objetos do SQL Server, mostrar a definição e criação de um Database e mostrarmos os tipos de dados de um SQL.',30,6,1,NULL,'aaaa'),(13,'SQLServer - Modulo 1','O curso básico de SQL Server explica a ferramenta, como iniciar o SETUP e como editar as informações no SGBD. Além disso, você aprenderá a eliminar valores duplicados e a realizar consultas avançadas.',40,9,1,12,'aaaa');

#
# Structure for table "CourseClasses"
#

DROP TABLE IF EXISTS `CourseClasses`;
CREATE TABLE `CourseClasses` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) DEFAULT NULL,
  `ClassNumber` int(11) NOT NULL,
  `CourseId` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_CourseClasses_CourseId` (`CourseId`),
  CONSTRAINT `FK_CourseClasses_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;

#
# Data for table "CourseClasses"
#

INSERT INTO `CourseClasses` VALUES (1,'Classe 1 - Introdução',1,1),(2,'Classe 1 - Introdução',1,2),(3,'Classe 1 - Introdução',1,3),(4,'Classe 1 - Introdução',1,4),(5,'Classe 1 - Introdução',1,5),(6,'Classe 1 - Introdução',1,6),(7,'Classe 1 - Introdução',1,7),(8,'Classe 1 - Introdução',1,8),(9,'Classe 1 - Introdução',1,9),(16,'Classe 2 - CSS Html e Javascript',2,1),(17,'Classe 2 - Div e Span',2,2),(18,'Classe 2 - Scripts e Loadings',2,3),(19,'Classe 2 - Colors e Backgroud',2,4),(20,'Classe 2 - Posicionamento pt1',2,5),(21,'Classe 2 - fors ifs e loops',2,6),(22,'Classe 2 - Escopo',2,7),(23,'Classe 2 - JQuery',2,8),(24,'Classe 2 - Angularjs pt1',2,9),(31,'Classe 3 - Requisições Http',3,1),(32,'Classe 3 - Ids Tags e Classes',3,2),(33,'Classe 3 - Herança',3,3),(34,'Classe 3 - Child e Parents',3,4),(35,'Classe 3 - z-index',3,5),(36,'Classe 3 - arrays e listas',3,6),(37,'Classe 3 - Tipos',3,7),(38,'Classe 3 - Libs e depenência',3,8),(39,'Classe 3 - Angularjs pt2',3,9),(40,'Classe 4 - Style e Links',4,3),(41,'Classe 4 - Posicionamento pt2',4,5),(42,'Classe 4 - npm',4,9),(43,'Classe 1 - Introdução',1,10),(44,'Classe 2 - Data-Attributes e libs',2,10),(45,'Classe 1 - Introdução',1,11),(46,'Classe 2 - shell e cmd',2,11),(47,'Classe 3 - Navegação',3,11),(48,'Classe 1 - Introdução',1,12),(49,'Classe 2 - SELECT',2,12),(50,'Classe 3 - SELECT e UPDATE',3,12),(51,'Classe 4 - JOIN',4,12),(52,'Classe 5 - PKs e FKs',5,12),(53,'Classe 6 - Procedures',6,12),(54,'Classe 1 - Introdução',1,13),(55,'Classe 2 - Arquitetura',2,13),(56,'Classe 3 - Modelagem',3,13);

#
# Structure for table "User"
#

DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) DEFAULT NULL,
  `Username` varchar(250) DEFAULT NULL,
  `Email` varchar(250) DEFAULT NULL,
  `MoneyEarned` float NOT NULL DEFAULT '0',
  `StudyHours` float NOT NULL DEFAULT '0',
  `TotalHour` float NOT NULL DEFAULT '0',
  `WorkedHours` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

#
# Data for table "User"
#

INSERT INTO `User` VALUES (1,'Luciano Galvão','luciano','lvgalval@gmail.com',1588.5,10,20,10),(2,'Rafael Brito','rfbrito','rfbrito@gmail.com',463.5,100,140,40),(3,'Willian Steffen','wsteffen','willian@livbox.com.br',200,10,20,10),(4,'Artur Cook','acook','acook@gmail.com',10,12,20,10);

#
# Structure for table "Jobs"
#

DROP TABLE IF EXISTS `Jobs`;
CREATE TABLE `Jobs` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Title` varchar(250) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `imagePath` varchar(250) DEFAULT NULL,
  `UserId` bigint(20) DEFAULT NULL,
  `UsedHours` float NOT NULL,
  `ReportedProgression` bigint(20) NOT NULL,
  `Completed` bit(1) NOT NULL,
  `Money` float NOT NULL DEFAULT '0',
  `BaseCode` longtext,
  `VerificationCode` longtext,
  `EstimatedHours` float NOT NULL DEFAULT '0',
  `ExtendedDescription` varchar(800) DEFAULT NULL,
  `Objective` varchar(800) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_Jobs_UserId` (`UserId`),
  CONSTRAINT `FK_Jobs_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`id`) ON DELETE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

#
# Data for table "Jobs"
#

INSERT INTO `Jobs` VALUES (1,'Programação da Aba de Grupos e Indicadores de um Sistema AIS','Precisamos do desenvolvimento back-end e fron-end de uma tela de cadastro de Grupos e Indicadores para um sistema AIS.','aa',1,4,100,b'1',140,NULL,NULL,40,'<p>Precisamos do desenvolvimento back-end e fron-end de uma tela de cadastro de Grupos e Indicadores para um sistema AIS. Será fornecido Mocks de dados do banco para a exibição na tela.</p>\r\n<p>A aba de cadastro de Grupos e Indicadores está dividida em duas seções: </p>\r\n<ul>\r\n\t<li>A primeira seção refere-se a campos de Pesquisa de Grupos e Indicadores de uma determinada Linha, Fase e Posto de Produção;</li>\r\n\t<li>A segunda seção refere-se a lista de resultados encontrados para a pesquisa realizada, apresentando a árvore de Grupos e Indicadores cadastrados em uma Linha, Fase e Posto de Produção.</li>\t\r\n</ul>','Esse projeto tem como objetivo fazer parte de um sistema completo AIS. '),(2,'Webservice Para um Sistema AIS','O Webservice permitirá acesso aos dados de Indicadores apontados no novo AIS através de um Webservice. Este Webservice poderá ser consumido por aplicações externas para, por exemplo, fazer o upload de dados para o SAP.','aa',1,0,100,b'1',40,NULL,NULL,13,'<p>O Webservice permitirá acesso aos dados de Indicadores apontados no novo AIS através de um Webservice. Este Webservice poderá ser consumido por aplicações externas para, por exemplo, fazer o upload de dados para o SAP.</p>\r\n\r\n<p>Os seguintes campos estarão disponíveis para filtro e visualização dos resultados através deste Webservice:</p>\r\n\r\n<ul>\r\n\t<li>Linha de produção</li>\r\n\t<li>Fase de produção</li>\t\r\n\t<li>Posto de produção</li>\r\n\t<li>Produto</li>\r\n\t<li>Turno</li>\r\n\t<li>Lote</li>\r\n\t<li>Grupo do indicador</li>\r\n\t<li>Indicador</li>\r\n\t<li>Resultado</li>\r\n\t<li>Hora apontamento</li>\r\n\t<li>Apontamento realizado</li>\r\n\t<li>Apontamento realizado</li>\r\n\t<li>Observação</li>\r\n\t<li>Operador</li>\r\n\t<li>Aprovado</li>\r\n</ul>\r\n\r\n<p>O sistema deve seguir padrões de uma WebAPI.</p>','Com o Webservice funcional poderemos conectar o sistema desenvolvido com outros sistemas.'),(3,'Ferramenta Customizada de Testes Javascript para Tela','Precisamos de uma ferramenta customizada para testes especificos em 4 telas do sistema. Você precisa desenvolver uma aplicação javascript adjcente a aplicação.','aa',1,0,100,b'1',233.5,NULL,NULL,120,'<p>Precisamos de uma ferramenta customizada para testes especificos em 4 telas do sistema. Você precisa desenvolver uma aplicação javascript adjcente a aplicação. Os testes precisam ser criados em funções independentes para poderem ser chamadas independentemente e checarem o resultado. Além disso as funções devem ser chamadas em ordem coerente por uma função geral.</p>\r\n<p>São as telas em questão:</p>\r\n\t<ul>\r\n\t\t<li>Tela de Apontamento de Paradas</li>\r\n\t\t<li>Tela de Qualidade</li>\r\n\t\t<li>Tela de KPIs</li>\r\n\t\t<li>Tela de Produção</li>\r\n\t</ul>\r\n\r\n<p>São um total de 10 fluxos por tela que devem ser desenvolvidos baseados no comportamento de um usuário padrão. </p>\r\n\r\n<p>O código será julgado por limpeza, clareza, complexidade dos testes realizados e adequação ao fluxo da tela.</p>','O objetivo é garantir a qualidade das telas desenvolvidas pela equipe in-house através de código independente.'),(5,'Geração dos Templates de Design para um sistema CMS','Precisamos gerar os Templates Front-End para um sistema CMS a ser desenvolvido. Esse sistema consiste em 5 telas distintas conectadas por um menu lateral.','aa',NULL,0,100,b'0',356,NULL,NULL,144,'Precisamos gerar os Templates Front-End para um sistema CMS a ser desenvolvido. Esse sistema consiste em 5 telas distintas conectadas por um menu lateral.\r\nO Sistema CMS apresenta três abas:\r\n• Relatórios: Esta é a tela na qual o supervisor pode acessar todos os relatórios de controle de processo gerados pelo Tablet e exportá-los para Excel; \r\n• Alertas : Esta tela permite a consulta e aprovação do supervisor de alertas gerados devido à desvios de limites máximos e mínimos de indicadores numéricos, resultados NÃO OK e NC (com problema de quebra ou sujeira) de indicadores booleanos, apontamentos não realizados ou atrasados; \r\n• Cadastros: Tela de cadastros de linhas, fases e postos de produção, produtos, grupos e indicadores e turnos de trabalho; ','O objetivo é viabilizar o desenvolvimento front-end da equipe in-house e agilizar a conexão do front-end com o back-end da aplicação.'),(6,'Desenvolvimento de um Sistema Node-SQL para inventário','É necessário o desenvolvimento de um sistema Node com base de Dados SQL.','aa',NULL,0,100,b'0',80,NULL,NULL,100,'É necessário o desenvolvimento de um sistema Node com base de Dados SQL segundo os seguintes requisitos:\r\n- O sistema deve gerar listas de conferência para o inventário de acordo com os critérios definidos no LMS;\r\n- O sistema deve enviar a lista para realização do inventário para os coletores;\r\n- O sistema não deve liberar uma lista para segunda ou terceira contagem onde a primeira ou segunda contagem foi realizada pelo mesmo usuário (exceto para filiais com estrutura de pessoal reduzido);','O trabalho é parte da construção de um sitema Node/SQL'),(7,'Desenvolvimento de um Sistema Node-SQL para conferência de Lotes','É necessário o desenvolvimento de um sistema Node com base de Dados SQL','aa',NULL,0,100,b'0',190,NULL,NULL,100,'É necessário o desenvolvimento de um sistema Node com base de Dados SQL segundo os seguintes requisitos:\r\n- Criação do lote de conferência / guarda baseado no xml do material de acordo com a locação (o sistema deve apresentar um relatório com o Número do lote / PN / SOS / Qtd / Locação / Status da conferência / Status da Guarda);\r\n- O lote de conferência deve ser conferido por N usuários (1 lote para N conferentes);\r\n- O sistema deve permitir o fechamento parcial do lote para guarda dos itens que tiveram a conclusão da conferência de todos os itens, caso exista um item que a quantidade total prevista para conferência ainda não tenha sido totalizada o sistema não irá liberar esse item para o lote de guarda gerando uma mensagem de bloqueio;','O trabalho é parte da construção de um sitema Node/SQL'),(8,'Ajuste Crítico de Telas de Produção de Fábrica','Necessário manipulação de um sistema em produção para controle de produção em fábrica. ','aa',1,0,100,b'1',800,NULL,NULL,200,'Necessário manipulação de um sistema em produção para controle de produção em fábrica. \r\nÉ necessário a manutenção de telas de processo de um sistema legado, cujo código fonte original não se encontra mais armazenado pela empresa em questão, se fazendo necessário engenharia reversa de diagramas SQL e códigos C++.\r\nA tela em questão se encontra ultrapassada em 5 anos com relação ao fluxo do processo atual, portanto o sistema em questão está sendo realizado manualmente. Uma vez o sistema MES estando reestabelecido a operação irá continua utilizando o sistema de forma imediata.\r\n\r\nO trabalho será julgado em 2 quesitos únicamente:\r\n1. Adequação ao processo atual\r\n2. Não dependência da base de dados atual, já que não há backup.','O objetivo é viabilizar novamente a utilização das telas em questão, já que o processo atualmente está sendo feito de forma manual.');

#
# Structure for table "JobsRequirements"
#

DROP TABLE IF EXISTS `JobsRequirements`;
CREATE TABLE `JobsRequirements` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `JobId` bigint(20) NOT NULL,
  `CourseId` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_JobsRequirements_CourseId` (`CourseId`),
  KEY `IX_JobsRequirements_JobId` (`JobId`),
  CONSTRAINT `FK_JobsRequirements_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_JobsRequirements_Jobs_JobId` FOREIGN KEY (`JobId`) REFERENCES `Jobs` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

#
# Data for table "JobsRequirements"
#

INSERT INTO `JobsRequirements` VALUES (1,1,1),(2,2,2),(3,3,1),(4,2,4),(5,5,6),(6,6,3),(7,7,10),(8,7,12),(9,8,1);

#
# Structure for table "UserCourses"
#

DROP TABLE IF EXISTS `UserCourses`;
CREATE TABLE `UserCourses` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `CourseId` bigint(20) NOT NULL,
  `UserId` bigint(20) NOT NULL,
  `UsedHours` float NOT NULL,
  `Progression` float NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_UserCourses_CourseId` (`CourseId`),
  KEY `IX_UserCourses_UserId` (`UserId`),
  CONSTRAINT `FK_UserCourses_Courses_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserCourses_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

#
# Data for table "UserCourses"
#

INSERT INTO `UserCourses` VALUES (3,1,1,1.4,100),(7,1,2,10,100),(8,2,2,10,100),(9,3,2,20,100),(19,10,2,10,30),(20,1,3,0,55),(21,3,3,0,0),(22,5,3,0,0),(23,2,1,0,0),(25,3,1,0,0),(26,7,1,0,0);

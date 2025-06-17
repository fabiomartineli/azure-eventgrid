# Azure Event Grid - Exemplo Prático com Web Apps

## 📌 Contexto

Em aplicações distribuídas modernas, a comunicação assíncrona entre serviços é fundamental para garantir escalabilidade, desempenho e desacoplamento. Nesse cenário, o uso de **eventos** se torna uma abordagem eficiente para que os serviços se comuniquem sem depender diretamente uns dos outros.

O **Azure Event Grid** é um serviço de roteamento de eventos totalmente gerenciado que permite criar arquiteturas orientadas a eventos de forma simples e eficaz. Ele fornece um mecanismo de publicação e assinatura de eventos com baixa latência e alta confiabilidade.

### 🧭 Diferença entre *Event Grid Topic* e *Event Grid Domain*

- **Event Grid Topic**: usado quando você tem uma única origem de eventos. Ideal para cenários simples, onde não há múltiplos emissores de eventos ou multitenancy.
- **Event Grid Domain**: indicado para cenários com múltiplos emissores (multitenancy). Permite organizar eventos em tópicos personalizados por cliente, departamento ou aplicação.

### 🔗 Conexões Possíveis

O Event Grid permite integração com diversas origens e destinos de eventos:

**Origens de eventos**:
- Azure Blob Storage
- Azure Resource Groups
- Custom Topics
- Event Hubs
- Aplicações customizadas

**Destinos de eventos**:
- Azure Functions
- Azure Logic Apps
- Webhooks
- Web Apps
- Service Bus Queues/Topics

### 🎯 Filtros em Subscriptions

O Event Grid permite aplicar filtros nas **subscriptions** para que somente eventos com determinadas características sejam encaminhados ao destino. Os filtros podem ser baseados em:
- Tipo de evento (`eventType`)
- Campos específicos no payload (`data`)
- Prefixos ou sufixos de assunto (`subject`)

### 🔄 Event Grid Event vs Cloud Event

- **Event Grid Event**: formato nativo da Azure, com campos como `eventType`, `subject`, `data`, `eventTime`, entre outros.
- **Cloud Event**: formato padronizado pela CNCF (Cloud Native Computing Foundation), com interoperabilidade entre provedores de nuvem.

O Azure Event Grid suporta ambos os formatos, tornando-o compatível com padrões abertos.

---
![image](https://github.com/user-attachments/assets/ffa5458c-ab62-46d4-b839-4df14cf938a0)

## 🛠 Desenvolvimento

O exemplo deste repositório implementa o seguinte fluxo:

### 1. **Criação de um Event Grid Domain** no portal Azure, para permitir múltiplos emissores de eventos simulando um ambiente multitenant.

Neste exemplo, foi criado um único domínio para fins de estudos, que poderia ser o domínio de Estoque por exemplo.

![image](https://github.com/user-attachments/assets/0301800e-ad1f-4d66-bcb8-2cf90baf6d50)

### 2. **Criação de duas Web Apps** na Azure, atuando como consumidores dos eventos.

### 3. **Criação de duas subscriptions dentro do Tópico criado**, correspondendo a contextos diferentes de eventos.

A criação de subscriptions via webhook necessita informar qual é o endpoint que irá receber os eventos.

![image](https://github.com/user-attachments/assets/41d47796-10cf-4adb-a3a0-c09bbfab41aa)

Cada subscription realiza o uso de filtro para receber eventos específicos. Esse uso simula o filtro por tipo do evento enviado.

![image](https://github.com/user-attachments/assets/8d39daf3-e53b-43f2-9d90-c912abd47159)
![image](https://github.com/user-attachments/assets/a7fb3ee2-fbab-4e93-8668-8e5fb5397bc3)

---

## 💻 Tecnologias Utilizadas

- **Azure Event Grid Domain**: usado para envio e roteamento de eventos em um ambiente distribuído.
- **.NET API**: aplicação desenvolvida em .NET para simular o envio e o consumo de eventos.
- **MongoDB**: utilizado para persistência dos dados dos eventos recebidos e para visualização do fluxo de mensagens.

---

## ✅ Conclusão

O Azure Event Grid é uma solução poderosa para arquiteturas orientadas a eventos, permitindo o desacoplamento entre componentes e a construção de sistemas escaláveis e reativos. Utilizando Domains e filtros, é possível criar fluxos de eventos altamente personalizados e seguros, com roteamento inteligente e baixo custo operacional.

Este exemplo demonstra como configurar um ambiente simples porém funcional com Event Grid Domain, múltiplos consumidores e filtros por tipo de evento. A flexibilidade do serviço o torna ideal para microsserviços, sistemas distribuídos e aplicações baseadas em eventos.

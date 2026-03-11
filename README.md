# Language [ENG](#description)/[RUS](#описание)

# Description
**This project corresponds to Mission 5 of the [Unity Junior Programmer roadmap](https://learn.unity.com/pathway/junior-programmer) on Unity Learn.**

# Technologies used
* Unity Editor v6000.2.11f1
* Vim 9.1 with dependencies:
  * OmniSharp LSP server
  * Unity tool [kotpodlawkoy sln generator](https://github.com/kotpodlawkoy/kotpodlawkoy.sln.csproj.generator)
 
# Link to web build
[play](https://play.unity.com/en/games/7c7c42c3-f292-4d0c-a95f-6549a5341d17/prototype5) (**Press Esc to exit to the main menu**)

# Work done
In the context of this project, the following was implemented:
* A prototype of a **side-view** 3D game where you have to hold down the mouse button and “cut” skulls (like in Fruit Ninja), which involved working with:
  * Unity UI
  * Event handling (from interface objects)
  * Difficulty mechanics
  * Full architecture in the form of a finite state machine with a main menu, game over, and pause
  * Background music volume control
  * Work with Trail Renderer to render a trail during “cutting”

* Prototype of a **top-down** 3D game **(path: ./Challenge 5/)**, where you have to smash anything on the board except skulls
  * Timer implemented using a coroutine
  * UI implemented with player score points

The project can be compiled in Unity

# Описание
**Проект соответствует 5-ой миссии [Unity Junior Programmer roadmap](https://learn.unity.com/pathway/junior-programmer) на Unity Learn**

# Использованные технологии
* Unity Editor v6000.2.11f1
* Vim 9.1 с зависимостями:
  * OmniSharp LSP server
  * Unity tool [kotpodlawkoy sln generator](https://github.com/kotpodlawkoy/kotpodlawkoy.sln.csproj.generator)
 
# Ссылка на web build
[играт](https://play.unity.com/en/games/7c7c42c3-f292-4d0c-a95f-6549a5341d17/prototype5) (**Нажмите Esc для выхода в главное меню**)

# Проведённая работа
В контексте данного проекта были реализованы:
* Прототип **side-view** 3D игры, где надо удерживать клавишу мыши и "разрезать" черепа (как во fruit ninja), где была проведена работа с:
  * Unity UI
  * Обработкой событий (от объектов интерфейса)
  * Сделана механика сложности
  * Полноценная архитектура в виде конечного автомата с главным меню, геймовером и паузой
  * Настройка громкости фоновой музыки
  * Работа с Trail Renderer для рендера шлейфа во время "разрезания"

* Прототип **top-down** 3D игры **(путь: ./Challenge 5/)**, где надо на доске лопать что угодно, кроме черепов
  * Реализован таймер с помощью корутины
  * Реализован UI с очками счёта игрока

Проект можно собрать в Unity

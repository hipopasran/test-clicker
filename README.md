<H1>Механика кликера и автосбора</H1>

<div>
Задача содержит перечень требований и описание функционала. Требуется разработать новый проект, который состоит из нескольких элементов:
  <ul>
    <li>
      Кнопка, нажатие на которую дает софт валюту
    </li>
    <li>
      Система «автосбор», дающая регулярный доход софт валюты (подробнее в
пункте «автосбор)
    </li>
    <li>
      Сделатьсвязьчерезмодификаторот«автосбора»кнажатиюна
«кликер» (подробнее в пункте «Автосбор»)
    </li>
    <li>
      Сделатьсвязьчерезмодификаторот«автосбора»кнажатиюна
«кликер» (подробнее в пункте «Автосбор»)
    </li>
  </ul>
Бонусом будет объяснение того, почему был выбран именно такой подход к реализации.
</div>
<h3>Краткое резюме задачи</h3>
<div>
  Создать систему получения софт валюты за тап. Создать «автосборщик», который каждые N секунд начисляет пассивно X софт валюты.
Опционально – сделать связь между кликером и автосбором, чтобы 10% от начисляемых автосбором средств прибавлялось к доходу, который игрок получает за каждый тап
(пример: если автосбор начисляет 100 софт валюты, то каждый тап должен давать дополнительно 10% софт валюты от 100)
</div>
<h3>Кликер (подробное описание)</h3>
<div>
  На главном экране находится кликер-объект, при нажатии на зону клика которого происходит списание X единиц энергии и начисление Y единиц софт валюты.
При сборе софт валюты возникает и “улетает” анимированное число софт валюты в количестве Y
</div>
<h3>Софт валюта за тап</h3>
<div>
  Количество получаемой софт валюты задается геймдизайнерами в scriptable object клик механики с помощью следующих переменных:
  <ul>
    <li>
      Базовое число софт валюты получаемое за тап
    </li>
      <li>
      Модификатор тапа (по умолчанию цифра, 1 к которой могут быть прибавлены
другие значения от других переменных)
    </li>
      <li>
      Модификатор иной переменной (состоит из двух множителей)
    </li>
    <li>
      Сумма доходов от заданного в настройках scriptable object значения в T времени
    </li>
    <li>
    Делитель, который задается гейм дизайнером в том же SO
    </li>
  </ul>
</div>
<h3>Автосбор</h3>
<div>
  Каждые N секунд игроку начисляется X софт валюты.
</div>
<h3>Дополнительная задача (опционально)</h3>
<div>10% от получаемой софт валюты X прибавляется к доходу c каждого тапа совершаемого игроком.</div>

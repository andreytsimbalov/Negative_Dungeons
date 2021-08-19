using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PageLister : MonoBehaviour
{
    int now_page = 0;
    public TMP_Text text_en;
    public TMP_Text text_ru;
    public bool isIntro = true;

    string[] manual_en = new string[]
   {
        "This story happened a long time ago in a far, distant place...",
        "One day a little girl returned home from a magic academy. She brought home bad news - she got a low grade on the exam...",
        "...math exam.",
        "Yes, the girl had poor knowledge of mathematics...",
        "...and in other subjects too...",
        "... she wasn't the smartest kid ever.",
        "Her father, the capitol archmage, was furious! His daughter's ignorance was an insult to his name.",
        "To teach his daughter a lesson, as well as improve her knowledge in mathematics, the magician sent her to the abandoned city of woodcutters, which was located at the foot of the volcano.",
        "...he was not the best father...",
        "However, for protection, the magician gave her a firefly firespitter.",
        "... the girl herself did not know how to conjure, she slept in magic lessons ...",
        "Sending his daughter on a dangerous adventure, the father gave her important advice ...",
        "'Remember two main truths: R - restart, T - next level.'",
        "If I don't understand anything, I can repeat everything - R. If everything is clear, go ahead - T."

   };

    string[] manual_ru = new string[]
   {
        "Эта история произошла давным-давно в далёком-далёком местe...",
        "Однажды маленькая девочка вернулась домой из магической академии. Она принесла домой плохие новости - ей поставили низкую оценку за экзамен...",
        "...экзамен по математике.",
        "Да, девочка имела плохие знания в математике...",
        "...и в остальных предметах тоже…",
        "...она вообще была не самым умным ребенком.",
        "Ее отец, верховный маг капитолия, был в ярости! Невежество дочери было оскорблением его имени.",
        "Чтобы проучить дочь, а также улучшить её знания в математике, маг отправил её в заброшенный город дровосеков, который находился у подножья вулкана.",
        "...он был не самым лучшим отцом…",
        "Однако для защиты маг дал ей светлячка-огнеплюя.",
        "...сама девочка колдовать не умела, на уроках магии она спала...",
        "Отправляя дочь в опасное приключение, отец дал ей важное наставление...",
        "'Запомни две главные истины: R - рестарт, T - следующие уровень.'",
        "Если ничего не поняла, могу всё повторить - R. Если всё ясно, ступай вперед - T."

   };

    string[] fin_en = new string[]
   {
        "After many attempts, the girl was able to pass all the tests.",
        "Was she able to learn math?",
        "Perhaps...",
        "...but she definitely learned to dodge the saws flying at her and not fall into the lava.",
        "And thank you for playing my game!",
        "GAME OVER",
        "GAME OVER?"

   };

    string[] fin_ru = new string[]
   {
        "Спустя множество попыток, девочка смогла пройти все испытания.",
        "Смогла ли она научиться математике?",
        "Возможно...",
        "...но она точно научилась уворачиваться от летящих в неё пил и не падать в лаву.",
        "И спасибо тебе, что играл в мою игру!",
        "Гамовер",
        "намек на сиквел"
   };
    string[] res_en;
    string[] res_ru;

    void Start()
    {
        if (isIntro)
        {
            res_en = manual_en;
            res_ru = manual_ru;
        }
        else
        {
            res_en = fin_en;
            res_ru = fin_ru;
        }
        NextPage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextPage();
        }
    }

    void NextPage()
    {
        if (now_page >= res_en.Length) return;

        text_en.text = res_en[now_page];
        text_ru.text = res_ru[now_page];
        now_page++;
    }

}

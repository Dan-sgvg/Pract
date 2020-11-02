using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM_Task_Number_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Финальный босс появляется!");
            int first_spell_damage; int second_spell_damage;int heal;
            int your_hp;int your_max_hp;int boss_hp;
            int chance_to_stun;
            int boss_strenght;int boss_armor;
            int boss_is_stun; int boss_rage; int your_rage;
            int life;
            Console.WriteLine("Введите уровень сложности (1-3):");
            int difficulty;
            bool isValidInt = int.TryParse(Console.ReadLine(), out difficulty);
            switch (difficulty)
            {
                case 1:
                    {
                        boss_hp = 100 * 5;
                        first_spell_damage = 80;
                        second_spell_damage = 100;
                        chance_to_stun = 3;
                        your_max_hp = 250;
                        boss_strenght = 25;
                        heal = 30;
                        break;
                    }

                case 2:
                    {
                        boss_hp = 100 * 8;
                        first_spell_damage = 65;
                        second_spell_damage = 80;
                        chance_to_stun = 5;
                        your_max_hp = 300;
                        boss_strenght = 35;
                        heal = 45;
                        break;
                    }
                case 3:
                    {
                        boss_hp = 100 * 12;
                        first_spell_damage = 40;
                        second_spell_damage = 60;
                        chance_to_stun = 8;
                        your_max_hp = 350;
                        boss_strenght = 45;
                        heal = 70;
                        break;
                    }
                default:
                    {
                        boss_hp = 100 * 5;
                        first_spell_damage = 80;
                        second_spell_damage = 100;
                        chance_to_stun = 3;
                        your_max_hp = 250;
                        boss_strenght = 25;
                        heal = 30;
                        break;
                    }

            }
            Random rnd = new Random();
            your_hp = your_max_hp;
            life = 1;
            your_rage = 1;
            boss_is_stun = 0;
            boss_armor = 0;
            boss_rage = 0;
            Console.WriteLine("\nСписок заклинаний:" + $"\n1- Удар посохом ( -{first_spell_damage * your_rage} здоровья босса / уничтожение брони). ");
            Console.WriteLine($"\n2- Рука тьмы  ( -{second_spell_damage * your_rage} здоровья босса / шанс оглушения). ");
            Console.WriteLine($"\n3- Использовать осколок тьмы (Осталось {life} шт).");
            Console.WriteLine($"\n4- Восстановление тьмы (+ {heal * your_rage}hp ). ");
            Console.WriteLine($"\n5- Самопожертвование ( -{heal}hp / *2 урон на след ход, станит босса).");

            while (your_hp > 0 && boss_hp > 0)
            {
                
                Console.WriteLine($"\nУ Босса {boss_hp} hp");
                if (boss_armor > 0)
                    Console.WriteLine($"У Босса {boss_armor} брони");
                Console.WriteLine($"У вас {your_hp} hp");
                if (your_rage > 1)
                        Console.WriteLine("Вы полны ярости.");
                
                    
                Console.WriteLine("Какое заклинание использовать?(1-5)");
                isValidInt = int.TryParse(Console.ReadLine(), out difficulty);
                switch (difficulty)
                {
                    case 1:
                        {
                            boss_hp -= (first_spell_damage * your_rage - boss_armor);
                            Console.WriteLine($"Вы нанесли боссу {first_spell_damage - boss_armor} урона.");
                            Console.WriteLine($"Вы уничтожили { boss_armor} ед брони босса.");
                            boss_armor = 0;
                            if (your_rage > 1)
                            {
                                your_rage -= 1;
                            }
                            break;
                        }
                    case 2:
                        {
                            boss_hp -= (second_spell_damage * your_rage - boss_armor);
                            Console.WriteLine($"Вы нанесли боссу {second_spell_damage - boss_armor} урона.");
                            if (rnd.Next(0, chance_to_stun) == 1)
                            {
                                boss_is_stun += 1;
                                Console.WriteLine("Вы застанили босса.");
                            }
                            if (your_rage > 1)
                            {
                                your_rage -= 1;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (life == 1)
                            {
                                Console.WriteLine($"Вы использовали осколок тьмы, ваше здоровье полностью восполнено. Ваш урон увеличен вдвое на следующий ход. ");
                                your_hp = your_max_hp;
                                your_rage += 1;
                                life -= 1;
                            }
                            else
                                Console.WriteLine("У вас больше нет осклков тьмы.");
                            break;
                        }
                    case 4:
                        {
                            your_hp += heal * your_rage;
                            Console.WriteLine($"Вы восстановили {heal * your_rage} hp.");
                            if (your_rage > 1)
                            {
                                your_rage -= 1;
                            }
                            break;
                        }
                    case 5:
                        {
                            your_hp -= heal;
                            your_rage += 1;
                            boss_is_stun += 1;
                            break;
                        }
                    default:
                        {
                            boss_hp -= first_spell_damage * your_rage - boss_armor;
                            Console.WriteLine($"Вы нанесли боссу {first_spell_damage - boss_armor} урона.");
                            boss_armor = 0;
                            break;
                        }
                }
                if (boss_hp < 0)
                    break;
                if (boss_is_stun == 0)
                {
                    Console.WriteLine("\n");
                    if (rnd.Next(0, 5) == 1)
                    {
                        Console.WriteLine("Босс повышает свою броню.");
                        boss_armor += 4;
                    }

                    if (rnd.Next(0, 5) == 1)
                    {
                        Console.WriteLine("Босс выглядит злым.");
                        boss_rage += 1;
                    }


                    your_hp -= boss_strenght * (boss_rage + 1);
                    Console.WriteLine($"Босс нанес вам {boss_strenght * (boss_rage + 1)} урона");
                    if (boss_rage > 0)
                        boss_rage -= 1;
                }
                else
                {
                    Console.WriteLine("Босс был застанен, поэтому не нанес вам урона");
                    boss_is_stun -= 1;
                }
            };
            if (your_hp <= 0)
                Console.WriteLine($"Вы проиграли, у босса осталось {boss_hp} hp");
            else
                Console.WriteLine($"Вы выиграли, поздравляю!");
            Console.ReadLine();

        }      
    }
}

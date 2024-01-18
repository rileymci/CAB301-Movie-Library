using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301
{
    class MemberCollection
    {
        

        public Member[] memberCollection;

        public int memberCount;

        public MemberCollection()
        {
            memberCollection = new Member[10];
            memberCount = 0;
        }


        public void registerMember(string firstName, string lastName, string address, string number, string password)
        {
            memberCollection[memberCount] = new Member(firstName, lastName, address, number, password);
            memberCount++;

            Console.WriteLine("\nSuccessfully added " + firstName + " " + lastName);

        }

        public void getPhoneNumber(string firstName, string lastName)
        {
            bool memberFound = false;
            int count = 0;

            foreach (Member member in memberCollection)
            {
                if (count == memberCount) { break; }

                if (firstName == member.firstname() && lastName == member.lastname())
                {

                    Console.WriteLine("\n" + firstName + " " + lastName + "'s phone number is: " + member.returnNumber());
                    memberFound = true;
                    break;
                }
                count++;
            }
            if (!memberFound)
            {
                Console.WriteLine("Member not found!");
            }

        }



    }
}

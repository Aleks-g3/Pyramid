using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pyramid.Entities;
using Pyramid.Util;

namespace Pyramid.Services
{
    public class OperationService :IOperationService
    {
        public Member GetHierarchy()
        {
            return FetchHierarchy();
        }

        public Account[] CreateAccounts(Member member)
        {
            return CreateAccountsByMembers(member);
        }

        public void ShowMembersWithSalary(Account[] accounts)
        {
            foreach (var account in accounts)
            {
                DisplayMember(account);
            }
        }

        public void MakeTransfers(ref Account[] accounts)
        {
            var transfers = GetTransfers();
            foreach (var transfer in transfers.transfers)
            {
                MakeTransferByAccount(ref accounts, transfer);
            }
        }

        private void MakeTransferByAccount(ref Account[] accounts,Transfer transfer)
        {
            var memberAccount = accounts.FirstOrDefault(a => a.Member.Id == transfer.MemberID);

            var founderAccount = accounts.First(a => a.Member.Id == 1);

            if (memberAccount != null)
            {
                founderAccount.IncrementAmount(transfer.Amount/2);
                var supervisor = accounts.First(a => a.Member.Id == memberAccount.Member.Parent.Id);
                supervisor.IncrementAmount(transfer.Amount / 2);
            }
        }

        private Transfers GetTransfers()
        {
            return XmlReaderExtensions.ReadDataFromFile<Transfers>("Przelewy.xml");
        }



        private Member FetchHierarchy()
        {
            var result = XmlReaderExtensions.ReadDataFromFile<PyramidEntity>("Piramida.xml");
            if (result != null)
            {
                SetParents(result.Member);
                return result.Member;
            }
            return null;
        }

        private void DisplayMember(Account account)
        {
            Console.WriteLine($"{account.Member.Id} {GetRowOfHierarchy(account)} {GetLengthArray(account)} {account.Amount}");
        }

        private int GetRowOfHierarchy(Account account)
        {
            int numberOfRow = 0;
            var member = account.Member;
            
            while (member.Parent!=null)
            {
                member = member.Parent;
                numberOfRow++;
            }

            return numberOfRow;
        }

        private int GetLengthArray(Account account)
        {
            return account.Member.Members?.Length ?? 0;
        }

        private void SetParents(Member member)
        {
            SetParent(member);
        }

        private void SetParent(Member member)
        {
            foreach (var tmpMember in member.Members)
            {
                tmpMember.Parent = member;
                if (tmpMember.Members != null)
                {
                    SetParent(tmpMember);
                }
            }
        }

        private Account[] CreateAccountsByMembers(Member member)
        {
            var listMembers = GetMembers(member);
            return listMembers.Select(m => new Account(m)).ToArray();
        }

        private List<Member> GetMembers(Member member)
        {
            var list = new List<Member>();

            list.Add(member);
            list.AddRange(GetMembersByMember(member));
            
            return list;
        }

        private List<Member> GetMembersByMember(Member member)
        {
            var tmpList = new List<Member>();

            foreach (var tmpMember in member.Members)
            {
                tmpList.Add(tmpMember);
                if (tmpMember.Members != null)
                {
                    tmpList.AddRange(GetMembersByMember(tmpMember)); 
                }
            }
            return tmpList;
        }
    }
}

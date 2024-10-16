Muhammad Rahim
ST10043611
PROG6212
POE PART 2

![image](https://github.com/user-attachments/assets/eae6e898-a749-4c9e-a632-74ddf0a2a589)


Table Of Contents
Part 2 — Implement a Prototype Web Application	3
GitHub Link:	3
Website Link:	3
Home Page 1	3
Home Page 2	4
Lecture Submit Claim 1	5
Lecture Submit Claim 2	5
Lecture Submit Claim 3	6
Lecture Submit Claim 4	6
Additional Feature Added	7
Coordinators/Managers Approval Claims Dashboard 1	8
Coordinators/Managers Approval Claims Dashboard 2	8
Lecture View Claims Dashboard Pending	9
Lecture View Claims Dashboard Approved	10
Lecture View Claims Dashboard Rejected	11
Edit Claim 1	12
Edit Claim 2	13
Remove Claim 1	14
Remove Claim 2	14
Unit Test 1	15
Unit Test 2	15
Unit Test 3	16
GitHub Branches	17
GitHub Commits 1	18
GitHub Commits 2	18
GitHub Commits 3	19
GitHub Commits 4	19
References Used for POE PART 2	20
References	20



Part 2 — Implement a Prototype Web Application
GitHub Link:
https://github.com/MuhammadRahimST10043611/Muhammad-Rahim_Prog6212-Poe-Part-2/tree/Final-Submission-Updated
Website Link:
https://st10043611prog.azurewebsites.net/

Please Note that no database was used all data is stored in lists as part 2 does not require the database. So therefore, your data will be saved for that session only and if you rerun you will have to reenter the data. 
Please Zoom Into the images to see them clearer.

Home Page 1
I Updated My Home Page to have buttons that lead you to each part of the website with ease to allow for a better UI and UX experience with a brief description of where each view will take you
 
![image](https://github.com/user-attachments/assets/b16983d7-14ff-4b34-8c18-eb3614d05080)


Home Page 2
I also Improved on the colour scheme allowing it to look more formal and stand out better to the users.
 
![image](https://github.com/user-attachments/assets/9f1067d8-4425-47d8-b824-d9dd694c2494)

















Lecture Submit Claim 1
Please find below all the features that were asked for the submit claim view.
![image](https://github.com/user-attachments/assets/24477790-b1e7-4534-8295-cce7e2eb1a6d)



Lecture Submit Claim 2
How it looks when data is inserted into the forms.
 

![image](https://github.com/user-attachments/assets/c93df25c-5b1e-44da-90c1-11b445e2da1d)





Lecture Submit Claim 3 
I have added a file type block which will throw this error message if the users try to submit a claim that is not either a PDF, Word or Excel document.
 
![image](https://github.com/user-attachments/assets/56e59e20-1243-42ba-a8da-e83c0d3ca032)


Lecture Submit Claim 4
I have added a file Size Limit of 5 MB which will throw this error message If they try to submit a file larger than 5mb it will output that message prompting the user to enter a file size of less than 5 MB
 
![image](https://github.com/user-attachments/assets/c19f51e5-d6c6-4f6e-8d72-9a253aabadec)


Additional Feature Added 
I’ve also added a feature where the user uploads an image, it will get uploaded to Azure file shares as well for safekeeping as a backup and it will be shown in the Approval Dashboard and the view claims dashboard.
 


![image](https://github.com/user-attachments/assets/d18e80ce-3abd-40d1-a26d-9ddd77561593)














Coordinators/Managers Approval Claims Dashboard 1 
In this view the Coordinator/Manager can either approve or reject the claim as well as I added a total amount feature which will take the hours worked and multiply it by the Hourly Rate to give the Total amount that must be paid to the lecture.
 ![image](https://github.com/user-attachments/assets/371bd4bd-ee78-4a0c-a1c7-a8f130d6077d)


Coordinators/Managers Approval Claims Dashboard 2
After the user chooses an action will clear it from this view and get sent to the View claims section and will display this message after so that the user is aware that there are no remaining claims
 ![image](https://github.com/user-attachments/assets/9fc806e3-e3e4-4115-a7b5-7653e925a741)

Lecture View Claims Dashboard Pending 
This is where the lecture will see whether their claim has been approved rejected or still pending he will also have the ability to edit the claim for revalution and the Coordinator/Managers will be able to remove the Claim. Please see image below of how it looks if a claim is still in the pending phase
 
![image](https://github.com/user-attachments/assets/782d479a-6579-41fc-bfaa-2e15b8e2971b)















Lecture View Claims Dashboard Approved
This is where the lecture will see whether their claim has been approved rejected or still pending he will also have the ability to edit the claim for revalution and the Coordinator/Managers will be able to remove the Claim. Please see image below of how it looks if a claim has been Approved.

 
![image](https://github.com/user-attachments/assets/a49a768a-e8b8-4fb7-bc8e-b13b375dc596)














Lecture View Claims Dashboard Rejected
This is where the lecture will see whether their claim has been approved rejected or still pending he will also have the ability to edit the claim for revalution and the Coordinator/Managers will be able to remove the Claim. Please see image below of how it looks if a claim has been Rejected.

 


![image](https://github.com/user-attachments/assets/baf579e4-79c0-4742-987b-784c1d8ccc0b)












Edit Claim 1
Please see image below of how the layout looks with regards if a lecture will have to edit his claim.
 



![image](https://github.com/user-attachments/assets/00e3a650-b3fb-44a6-bca9-51e8bc5ace62)
















Edit Claim 2
Please see below how it will look if the Coordinator/Manager reevaluates the claim they will be given an option by status to change it to either pending, rejected or approved.
 


![image](https://github.com/user-attachments/assets/1f04d5c6-995e-407f-bd3b-d55e5e47629e)
















Remove Claim 1
I also added the feature to be able to remove the Claims
 ![image](https://github.com/user-attachments/assets/4be326db-1864-49da-ab8b-c4a0b49faca5)


Remove Claim 2
 
![image](https://github.com/user-attachments/assets/fbc65d45-1521-4a95-b1a9-27c6553e416e)





Unit Test 1
Please find below the code for my unit test part 1
 
![image](https://github.com/user-attachments/assets/672918a4-3bf2-46d5-a4e4-38554fc69bf0)


Unit Test 2
Please find below the code for my unit test part 2
 
![image](https://github.com/user-attachments/assets/361b3d63-f40e-4cf0-a6b7-052c47f33d97)





Unit Test 3 
Please find below the proof of my Unit Test that ran successfully 
 
![image](https://github.com/user-attachments/assets/00886eb6-e586-473e-864d-ff608b0131bb)


















GitHub Branches
Please Find Below all my GitHub Branches with the final Branch that must be marked is “Final-Submission-Updated”

![image](https://github.com/user-attachments/assets/a9045bf4-d594-46ab-8439-dbd123a8bee7)

 
















GitHub Commits 1
Please find below the number of commits that were made to this GitHub which was 15 in the final branch.
![image](https://github.com/user-attachments/assets/d257a130-ea11-4f07-8c77-84862288417b)
 

GitHub Commits 2
Please find below the commits 1-3 with clear and descriptive commit messages
 
![image](https://github.com/user-attachments/assets/57067006-bfb1-4c80-8891-81e85195dc18)









GitHub Commits 3
Please find below the commits 4-10 with clear and descriptive commit messages

![image](https://github.com/user-attachments/assets/f85a5b21-aca4-4524-98ed-ed28f2edf111)


GitHub Commits 4
Please find below the commits 11-15 with clear and descriptive commit messages
 
![image](https://github.com/user-attachments/assets/2cc6b886-e7e7-4b07-a57d-153880fcd880)



References Used for POE PART 2
(GeeksForGeeks, 2022) (Kim, 2024) (Kim, 2024) (Kim, 2024) (Kim, 2024) (Kim, 2024) (Kim, 2024) (w3schools, n.d.) (ChatGPT, 2024)

References
ChatGPT, 2024. Problem solving my error with views and claims. [Online] 
Available at: https://chatgpt.com/c/67085741-54d0-8009-aacf-08a61c23c9be
[Accessed 15 October 2024].
GeeksForGeeks, 2022. ArrayList in C#. [Online] 
Available at: https://www.geeksforgeeks.org/arraylist-in-c-sharp/?ref=shm
[Accessed 7 September 2024].
Kim, Y.-S., 2024. LU1_Theme1_Operator_Overloading, Cape Town: Youn-Soo Kim.
Kim, Y.-S., 2024. LU1_Theme2_Object_Lifetime, Yoon-Soo Kim: Cape Town.
Kim, Y.-S., 2024. Theme 1: Advanced C# Features, Cape Town: Youn-Soo Kim.
Kim, Y.-S., 2024. Theme 1: Building and Configuring Class Libraries, Cape Town: Youn-Soo Kim.
Kim, Y.-S., 2024. Theme 3: Dynamic Types and the Dynamic, Cape Town: Youn-Soo Kim.
Kim, Y.-S., 2024. Theme 3: Language Integrated Queries, Cape Town: Youn-Soo Kim.
Kim, Y.-S., 2024. Youn-Soo Kim, Cape Town: Youn-Soo Kim.
w3schools, n.d. ASP and ASP.NET Tutorials. [Online] 
Available at: https://www.w3schools.com/asp/default.ASP
[Accessed 25 May 2024].



